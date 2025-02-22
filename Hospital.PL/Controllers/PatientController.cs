using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class PatientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public PatientController( IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index(string Search)
        {
            var patient = Enumerable.Empty<Patient>();

            if (string.IsNullOrEmpty(Search))
                patient = _UnitOfWork.PatientRepository.GetAll(); 
            else 
                patient = _UnitOfWork.PatientRepository.SearchByName(Search.ToLower());

            var mapp = _mapper.Map<IEnumerable<Patient>,IEnumerable<PatientViewModel>>(patient);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PatientViewModel patientViewModel)
        {       

            var mapp = _mapper.Map<PatientViewModel,Patient>(patientViewModel);
            if(ModelState.IsValid)
            {

                _UnitOfWork.PatientRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                   return RedirectToAction(nameof(Index));
            }
           
            return View(patientViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var patient = _UnitOfWork.PatientRepository.GetById(Id.Value);

            var mapperDP = _mapper.Map<Patient, PatientViewModel>(patient);
            if (patient == null)
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
        public IActionResult Update([FromRoute] int Id, PatientViewModel patientViewModel)
        {
            if (Id != patientViewModel.ID)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    var mapp = _mapper.Map<PatientViewModel, Patient>(patientViewModel);
                    _UnitOfWork.PatientRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                      return  RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(patientViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id:Id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, PatientViewModel PatientVm)
        {
            if (Id != PatientVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<PatientViewModel, Patient>(PatientVm);

                _UnitOfWork.PatientRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(PatientVm);
        }
    }
}
