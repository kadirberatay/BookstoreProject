using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		ICategoryDal _categoryDal;
		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public IResult Add(CategoryDto category)
		{
			IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.Name));

			if (result != null)
			{
				return result;
			}

			_categoryDal.Add(category);
			return new SuccessResult(Messages.EntityAdded);
		}

		public IResult Delete(int id)
		{
			_categoryDal.Delete(id);
			return new SuccessResult(Messages.EntityDeleted);
		}

		public IDataResult<List<CategoryDto>> GetAll()
		{
			return new SuccessDataResult<List<CategoryDto>>(_categoryDal.GetAll());
		}

		public IDataResult<CategoryDto> GetById(int id)
		{
			return new SuccessDataResult<CategoryDto>(_categoryDal.Get(p => p.Id == id));
		}

		public IResult Update(CategoryDto category)
		{
			IResult result = BusinessRules.Run(CheckIfCategoryNameExists(category.Name, category.Id));

			if (result != null)
			{
				return result;
			}

			_categoryDal.Update(category);

			return new SuccessResult(Messages.EntityUpdated);
		}

		private IResult CheckIfCategoryNameExists(string Name, int? categoryId = null)
		{
			var result = _categoryDal.GetAll(p => p.Name == Name && (categoryId == null || p.Id != categoryId)).Any();
			if (result)
			{
				return new ErrorResult(Messages.CategoryNameAlreadyExists);
			}

			return new SuccessResult();
		}
	}
}
