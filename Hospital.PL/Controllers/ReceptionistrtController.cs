using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public ReceptionistController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index(string Search)
        {
            var Receptionist = Enumerable.Empty<Receptionist>();

            if (string.IsNullOrEmpty(Search))
                Receptionist = _UnitOfWork.ReceptionistRepository.GetAll();
            else
                Receptionist = _UnitOfWork.ReceptionistRepository.SearchByName(Search.ToLower());

            var mapp = _mapper.Map<IEnumerable<Receptionist>, IEnumerable<ReceptionistViewModel>>(Receptionist);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ReceptionistViewModel ReceptionistViewModel)
        {
            var mapp = _mapper.Map<ReceptionistViewModel, Receptionist>(ReceptionistViewModel);
            if (ModelState.IsValid)
            {

                _UnitOfWork.ReceptionistRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                   return RedirectToAction(nameof(Index));
            }

            return View(ReceptionistViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var Receptionist = _UnitOfWork.ReceptionistRepository.GetById(Id.Value);

            if (Receptionist == null)
                return NotFound();
            var mapperDP = _mapper.Map<Receptionist, ReceptionistViewModel>(Receptionist);

            return View(ViewName, mapperDP);
        }
        [HttpGet]
        public IActionResult Update(int? Id)
        {

            if (Id == null)
                return BadRequest();
            var Receptionist = _UnitOfWork.ReceptionistRepository.GetById(Id.Value);
             
            if (Receptionist == null)
                return NotFound();
            var mapperDP = _mapper.Map<Receptionist,ReceptionistViewModel>(Receptionist);
            return View(mapperDP);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute] int Id, ReceptionistViewModel ReceptionistViewModel)
        {
            if (Id != ReceptionistViewModel.ID)
                return BadRequest();

            try
            {
                if (ModelState.IsValid)
                {
                    var mapp = _mapper.Map<ReceptionistViewModel, Receptionist>(ReceptionistViewModel);
                    _UnitOfWork.ReceptionistRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(ReceptionistViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id: Id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, ReceptionistViewModel ReceptionistVm)
        {
            if (Id != ReceptionistVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<ReceptionistViewModel, Receptionist>(ReceptionistVm);

                _UnitOfWork.ReceptionistRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(ReceptionistVm);
        }
       
    }
}
