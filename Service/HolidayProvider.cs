using Abp.Net.Mail;
using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Repository;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Service
{
    public interface IHolidayProvider
    {
        int SaveHoliday(HolidayViewModel model);
        HolidayViewModel GetById(int id);
    }
    public class HolidayProvider : IHolidayProvider
    {
        private readonly IHolidayRepository _iHolidayRepository;
        private readonly IMapper _mapper;
        public HolidayProvider(IHolidayRepository iHolidayRepository, IMapper mapper)
        {
            _iHolidayRepository = iHolidayRepository;
            _mapper = mapper;
        }
        public int SaveHoliday(HolidayViewModel model)
        {
            Holiday holiday = new Holiday();
            holiday = _mapper.Map<Holiday>(model);
            _iHolidayRepository.Add(holiday);
            return 200;
        }
        public HolidayViewModel GetById(int id)
        {
            var item = _iHolidayRepository.GetSingle(x => x.Holiday_Id == id);
            HolidayViewModel data = _mapper.Map<HolidayViewModel>(item);
            return data;
        }
        public HolidayViewModel GetList()
        {
            HolidayViewModel model = new HolidayViewModel();
            var list = new List<HolidayViewModel>();
            List<Holiday> data = _iHolidayRepository.GetAll().ToList();
            list = _mapper.Map<List<Holiday>, List<HolidayViewModel>>(data);
            model.HolidayList = list;
            return model;
        }
    }

}

