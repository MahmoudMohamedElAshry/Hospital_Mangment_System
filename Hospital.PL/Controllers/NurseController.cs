using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class NurseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public NurseController( IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index(string Search)
        {
            var Nurse = Enumerable.Empty<Nurse>();

            if (string.IsNullOrEmpty(Search))
                Nurse = _UnitOfWork.NurseRepository.GetAll(); 
            else 
                Nurse = _UnitOfWork.NurseRepository.SearchByName(Search.ToLower());

            var mapp = _mapper.Map<IEnumerable<Nurse>,IEnumerable<NurseViewModel>>(Nurse);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NurseViewModel NurseViewModel)
        {       

            var mapp = _mapper.Map<NurseViewModel,Nurse>(NurseViewModel);
            if(ModelState.IsValid)
            {

                _UnitOfWork.NurseRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                   return RedirectToAction(nameof(Index));
            }
           
            return View(NurseViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var Nurse = _UnitOfWork.NurseRepository.GetById(Id.Value);

            var mapperDP = _mapper.Map<Nurse, NurseViewModel>(Nurse);
            if (Nurse == null)
                return NotFound();
            return View(ViewName, mapperDP);
        }
        [HttpGet]
        public IActionResult Update(int? Id)
        {
            return Details(Id,nameof(Update));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute] int Id, NurseViewModel NurseViewModel)
        {
            if (Id != NurseViewModel.ID)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    var mapp = _mapper.Map<NurseViewModel, Nurse>(NurseViewModel);
                    _UnitOfWork.NurseRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                      return  RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(NurseViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id:Id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, NurseViewModel NurseVm)
        {
            if (Id != NurseVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<NurseViewModel, Nurse>(NurseVm);

                _UnitOfWork.NurseRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(NurseVm);
        }
    }
}
