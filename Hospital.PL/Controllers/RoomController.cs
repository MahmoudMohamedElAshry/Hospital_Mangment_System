using AutoMapper;
using Hospital.BLL.Interfaces;
using Hospital.BLL.Repositories;
using Hospital.DAL.Models;
using Hospital.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Hospital.PL.Controllers
{
    public class RoomController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _UnitOfWork;

        public RoomController( IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _UnitOfWork = unitOfWork;
        }
        public IActionResult Index(int? Search)
        {
            var room = Enumerable.Empty<Room>();

            if (!Search.HasValue)
                room = _UnitOfWork.RoomRepository.GetAll(); 
            else 
                room = _UnitOfWork.RoomRepository.SearchByNumber(Search.Value);

            var mapp = _mapper.Map<IEnumerable<Room>,IEnumerable<RoomViewModel>>(room);

            return View(mapp);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RoomViewModel roomViewModel)
        {
            if(ModelState.IsValid)
            {
                var mapp = _mapper.Map<RoomViewModel,Room>(roomViewModel);
                _UnitOfWork.RoomRepository.Create(mapp);
                var count = _UnitOfWork.Complete();
                if (count > 0)
                   return RedirectToAction(nameof(Index));
            }
            return View(roomViewModel);
        }
        [HttpGet]
        public IActionResult Details(int? Id, string ViewName = "Details")
        {
            if (Id == null)
                return BadRequest();
            var room = _UnitOfWork.RoomRepository.GetById(Id.Value);
            var mapperDP = _mapper.Map<Room,RoomViewModel>(room);
            if (room == null)
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
        public IActionResult Update([FromRoute] int Id, RoomViewModel roomViewModel)
        {
            if (Id != roomViewModel.ID)
                return BadRequest();

            try
            {
                if(ModelState.IsValid)
                {
                    var mapp = _mapper.Map<RoomViewModel,Room>(roomViewModel);
                    _UnitOfWork.RoomRepository.Update(mapp);
                    var count = _UnitOfWork.Complete();
                    if (count > 0)
                      return  RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(roomViewModel);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            return Details(ViewName: "Delete", Id: Id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([FromRoute] int Id, RoomViewModel roomVm)
        {
            if (Id != roomVm.ID)
                return BadRequest();

            try
            {
                var mapperDP = _mapper.Map<RoomViewModel,Room>(roomVm);
                _UnitOfWork.RoomRepository.Delete(mapperDP);
                _UnitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(roomVm);
        }
        //[HttpGet]
        //public IActionResult Inside(int Id)
        //{
        //    var patient = _UnitOfWork.PatientRepository.GetPatientByRoomId(Id);
        //    if (patient == null)
        //    {
        //        return NotFound();
        //    }
        //    var mapp = _mapper.Map<IEnumerable<Patient>,IEnumerable<PatientViewModel>>(patient);

        //    return View(mapp);
        //}

    }
}
