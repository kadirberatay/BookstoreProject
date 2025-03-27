using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface ICategoryService
	{
		IResult Add(CategoryDto categoryDto);
		IResult Delete(int id);
		IResult Update(CategoryDto categoryDto);
		IDataResult<List<CategoryDto>> GetAll();
		IDataResult<CategoryDto> GetById(int id);
	}
}
