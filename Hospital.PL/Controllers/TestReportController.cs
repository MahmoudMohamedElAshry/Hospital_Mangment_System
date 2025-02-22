using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class TestReportController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public TestReportController( IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
              var TestReport = _UnitOfWork.TestReportRepository.GetAll(); 

            var mapp = _mapper.Map<IEnumerable<TestReport>,IEnumerable<TestReportViewModel>>(TestReport);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TestReportViewModel testReportViewModel)
        {
            if(ModelState.IsValid)
            {
                var mapp = _mapper.Map<TestReportViewModel,TestReport>(testReportViewModel);
                _UnitOfWork.TestReportRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                 return RedirectToAction(nameof(Index));
            }
            return View(testReportViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var testReport = _UnitOfWork.TestReportRepository.GetById(Id.Value);
            var mapperDP = _mapper.Map<TestReport,TestReportViewModel>(testReport);
            if (testReport == null)
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
        public IActionResult Update([FromRoute] int Id, TestReportViewModel testReportViewModel)
        {
            if (Id != testReportViewModel.ID)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    var mapp = _mapper.Map<TestReportViewModel,TestReport>(testReportViewModel);
                    _UnitOfWork.TestReportRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                      return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(testReportViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id: Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, TestReportViewModel testReportVm)
        {
            if (Id != testReportVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<TestReportViewModel,TestReport>(testReportVm);
                _UnitOfWork.TestReportRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(testReportVm);
        }
       
    }
}
