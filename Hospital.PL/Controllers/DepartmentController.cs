using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public DepartmentController( IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index(string Search)
        {
            var Department = Enumerable.Empty<Department>();

            if (string.IsNullOrEmpty(Search))
                Department = _UnitOfWork.DepartmentRepository.GetAll(); 
            else 
                Department = _UnitOfWork.DepartmentRepository.SearchByName(Search.ToLower());

            var mapp = _mapper.Map<IEnumerable<Department>,IEnumerable<DepartmentViewModel>>(Department);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentViewModel DepartmentViewModel)
        {
            if(ModelState.IsValid)
            {
                var mapp = _mapper.Map<DepartmentViewModel,Department>(DepartmentViewModel);
                _UnitOfWork.DepartmentRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                   return RedirectToAction(nameof(Index));
            }
            return View(DepartmentViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var Department = _UnitOfWork.DepartmentRepository.GetById(Id.Value);
            var mapperDP = _mapper.Map<Department,DepartmentViewModel>(Department);
            if (Department == null)
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
        public IActionResult Update([FromRoute] int Id, DepartmentViewModel DepartmentViewModel)
        {
            if (Id != DepartmentViewModel.ID)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    var mapp = _mapper.Map<DepartmentViewModel,Department>(DepartmentViewModel);
                    _UnitOfWork.DepartmentRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                      return  RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(DepartmentViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id: Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, DepartmentViewModel DepartmentVm)
        {
            if (Id != DepartmentVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<DepartmentViewModel,Department>(DepartmentVm);
                _UnitOfWork.DepartmentRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(DepartmentVm);
        }
    }
}
