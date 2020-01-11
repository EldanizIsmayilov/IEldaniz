using IEldaniz.BusinessLogicLayer.Abstractions.Services;
using IEldaniz.BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEldaniz.DataAccessLayer.Abstractions;
using IEldaniz.DataAccessLayer.Entities;
using AutoMapper;

namespace IEldaniz.BusinessLogicLayer.ServiceImplementations
{
    public class SampleService : ISampleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SampleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        IEnumerable<SampleDto> ISampleService.GetAll()
        {
            var result = _unitOfWork.SampleEntityRepository.GetAll();

            return Mapper.Map<IEnumerable<SampleDto>>(result);
        }

        SampleDto ISampleService.Get(int id)
        {
            var result = _unitOfWork.SampleEntityRepository.Get(x => x.Id == id);

            return Mapper.Map<SampleDto>(result);
        }

        SampleDto ISampleService.Add(SampleDto sample)
        {
            var newSample = Mapper.Map<SampleEntity>(sample);

            _unitOfWork.SampleEntityRepository.Add(newSample);
            _unitOfWork.SaveChanges();

            return Mapper.Map<SampleDto>(newSample);
        }

        SampleDto ISampleService.Update(int id, SampleDto sample)
        {
            var registeredSample = _unitOfWork.SampleEntityRepository.Get(x => x.Id == id);
            registeredSample.Name = sample.Name;
            registeredSample.Patronymic = sample.Patronymic;
            registeredSample.Surname = sample.Surname;
            _unitOfWork.SaveChanges();

            return Mapper.Map<SampleDto>(registeredSample);
        }

        void ISampleService.Delete(int id)
        {
            _unitOfWork.SampleEntityRepository.Delete(x => x.Id == id);
            _unitOfWork.SaveChanges();
        }
    }
}
