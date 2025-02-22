using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class BillController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public BillController( IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
              var Bill = _UnitOfWork.BillRepository.GetAll(); 

            var mapp = _mapper.Map<IEnumerable<Bill>,IEnumerable<BillViewModel>>(Bill);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BillViewModel BillViewModel)
        {
            if(ModelState.IsValid)
            {
                var mapp = _mapper.Map<BillViewModel,Bill>(BillViewModel);
                _UnitOfWork.BillRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                 return RedirectToAction(nameof(Index));
            }
            return View(BillViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var Bill = _UnitOfWork.BillRepository.GetById(Id.Value);
            var mapperDP = _mapper.Map<Bill,BillViewModel>(Bill);
            if (Bill == null)
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
        public IActionResult Update([FromRoute] int Id, BillViewModel BillViewModel)
        {
            if (Id != BillViewModel.ID)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    var mapp = _mapper.Map<BillViewModel,Bill>(BillViewModel);
                    _UnitOfWork.BillRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                      return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(BillViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id: Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, BillViewModel BillVm)
        {
            if (Id != BillVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<BillViewModel,Bill>(BillVm);
                _UnitOfWork.BillRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(BillVm);
        }
       
    }
}
