using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public DoctorController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index(string Search)
        {
            var doctor = Enumerable.Empty<Doctor>();

            if (string.IsNullOrEmpty(Search))
                doctor = _UnitOfWork.DoctorRepository.GetAll();
            else
                doctor = _UnitOfWork.DoctorRepository.SearchByName(Search.ToLower());

            var mapp = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorViewModel>>(doctor);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DoctorViewModel doctorViewModel)
        {
            var mapp = _mapper.Map<DoctorViewModel, Doctor>(doctorViewModel);
            if (ModelState.IsValid)
            {

                _UnitOfWork.DoctorRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                   return RedirectToAction(nameof(Index));
            }

            return View(doctorViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var doctor = _UnitOfWork.DoctorRepository.GetById(Id.Value);

            if (doctor == null)
                return NotFound();
            var mapperDP = _mapper.Map<Doctor, DoctorViewModel>(doctor);

            return View(ViewName, mapperDP);
        }
        [HttpGet]
        public IActionResult Update(int? Id)
        {

            if (Id == null)
                return BadRequest();
            var doctor = _UnitOfWork.DoctorRepository.GetById(Id.Value);
             
            if (doctor == null)
                return NotFound();
            var mapperDP = _mapper.Map<Doctor,DoctorViewModel>(doctor);
            return View(mapperDP);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromRoute] int Id, DoctorViewModel doctorViewModel)
        {
            if (Id != doctorViewModel.ID)
                return BadRequest();

            try
            {
                if (ModelState.IsValid)
                {
                    var mapp = _mapper.Map<DoctorViewModel, Doctor>(doctorViewModel);
                    _UnitOfWork.DoctorRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                        return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(doctorViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id: Id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, DoctorViewModel doctorVm)
        {
            if (Id != doctorVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<DoctorViewModel, Doctor>(doctorVm);

                _UnitOfWork.DoctorRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(doctorVm);
        }
        //[HttpGet]
        //public IActionResult Follow(int? doctorId)
        //{  
        //    if (doctorId == null)
        //        return BadRequest();
        //    var patoent = _UnitOfWork.PatientRepository.GetPatientByDoctor(doctorId.Value);
           
        //   if(doctorId == null)
        //        return NotFound();
        //    var mapp = _mapper.Map<IEnumerable<Patient>, IEnumerable<PatientViewModel>>(patoent);

        //    return View(mapp);
        //}
    }
}
