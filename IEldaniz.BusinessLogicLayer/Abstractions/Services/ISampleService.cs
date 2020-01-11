using IEldaniz.BusinessLogicLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.BusinessLogicLayer.Abstractions.Services
{
    public interface ISampleService
    {
        IEnumerable<SampleDto> GetAll();

        SampleDto Get(int id);

        SampleDto Add(SampleDto sample);

        SampleDto Update(int id, SampleDto sample);

        void Delete(int id);
    }
}
