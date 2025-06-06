﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryPersonelPenaltyManager : IMilitaryPersonelPenaltyService
    {
        public IMilitaryPersonelPenaltyDal _militaryPersonelPenaltyDal;
        public IMapper _mapper;

        public MilitaryPersonelPenaltyManager(IMilitaryPersonelPenaltyDal militaryPersonelPenaltyDal, IMapper mapper)
        {
            _militaryPersonelPenaltyDal = militaryPersonelPenaltyDal;
            _mapper = mapper;
        }

        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesAsync()
        {
            List<PenaltyGetDto> list = await _militaryPersonelPenaltyDal.GetAllPenaltiesAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PenaltyGetDto>>(list);
            }
            return new ErrorDataResult<List<PenaltyGetDto>>(Messages.NoData);
        }


        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesByPersonelIdAsync(int personelId)
        {
            List<PenaltyGetDto> list = await _militaryPersonelPenaltyDal.GetAllPenaltiesByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PenaltyGetDto>>(list);
            }
            return new ErrorDataResult<List<PenaltyGetDto>>(Messages.NoData);
        }

        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesByPenaltyTypeIdAsync(int penaltyTypeId)
        {
            List<PenaltyGetDto> list = await _militaryPersonelPenaltyDal.GetAllPenaltiesByPenaltyTypeIdAsync(penaltyTypeId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PenaltyGetDto>>(list);
            }
            return new ErrorDataResult<List<PenaltyGetDto>>(Messages.NoData);
        }

        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesByInjunctiondAsync(int injunctionId)
        {
            List<PenaltyGetDto> list = await _militaryPersonelPenaltyDal.GetAllPenaltiesByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PenaltyGetDto>>(list);
            }
            return new ErrorDataResult<List<PenaltyGetDto>>(Messages.NoData);
        }


        [SecuredOperation("admin,cmd.get")]
        [CacheAspect]
        public async Task<IDataResult<PenaltyGetDto>> GetPenaltyByIdAsync(int id)
        {
            PenaltyGetDto entity = await _militaryPersonelPenaltyDal.GetPenaltyByIdAsync(id);
            if (entity != null)
            {
                return new SuccessDataResult<PenaltyGetDto>(entity);
            }
            return new ErrorDataResult<PenaltyGetDto>(Messages.EntityNotFound);
        }

        [CacheRemoveAspect("IMilitaryPersonelPenaltyService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryPersonelPenaltyValidator))]
        public async Task<IResult> AddPenaltyAsync(PenaltyAddDto dto)
        {
            var entity = _mapper.Map<MilitaryPersonelPenalty>(dto);
            await _militaryPersonelPenaltyDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }

        [CacheRemoveAspect("IMilitaryPersonelPenaltyService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(MilitaryPersonelPenaltyValidator))]
        public async Task<IResult> UpdatePenaltyAsync(PenaltyUpdateDto dto)
        {
            MilitaryPersonelPenalty entity = await _militaryPersonelPenaltyDal.GetAsync(p => p.Id == dto.Id);
            if (entity != null)
            {
                _mapper.Map(dto, entity);
                await _militaryPersonelPenaltyDal.UpdateAsync(entity);
                return new SuccessResult(Messages.SuccessfullyUpdated);
            }
            return new ErrorResult(Messages.EntityNotFound);
        }

        [CacheRemoveAspect("IMilitaryPersonelPenaltyService.Get")]
        [SecuredOperation("admin")]

        public async Task<IResult> DeletePenaltyAsync(int id)
        {
            MilitaryPersonelPenalty entity = await _militaryPersonelPenaltyDal.GetAsync(p => p.Id == id);
            if (entity != null)
            {
                await _militaryPersonelPenaltyDal.DeleteAsync(entity);
                return new SuccessResult(Messages.SuccessfullyDeleted);
            }
            return new ErrorResult(Messages.EntityNotFound);
        }


    }
}
