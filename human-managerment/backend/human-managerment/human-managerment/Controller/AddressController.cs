using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HumanManagermentBackend.Dto;
using HumanManagermentBackend.Entities;
using HumanManagermentBackend.Models;
using HumanManagermentBackend.Services;
using HumanManagermentBackend.Services.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HumanManagermentBackend.Controller
{
    [Route("/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ProvinceService _provinceService;
        private readonly DistrictService _districtService;
        private readonly WardService _wardService;
        private readonly AddressService _addressService;

        public AddressController(ProvinceServiceImpl provinceService, DistrictServiceImpl districtService
                                ,WardServiceImpl wardService, AddressServiceImpl addressService)
        {
            _provinceService = provinceService;
            _districtService = districtService;
            _wardService = wardService;
            _addressService = addressService;
        }
        [HttpGet("province")]
        public ActionResult<Api<List<ProvinceDTO>>> GetAllProvince(//
                                                              [FromQuery(Name = "page"), DefaultValue(1)] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                              )
        {

            int totalItems = _provinceService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<ProvinceDTO> dtos = _provinceService.FindAll(page, limit);

            Api<List<ProvinceDTO>> result = new Api<List<ProvinceDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }
        [HttpPost("province")]
        public ActionResult<Api<ProvinceDTO>> AddProvince(ProvinceEntity province)
        {
            ProvinceDTO dto = _provinceService.save(province);

            Api<ProvinceDTO> result = new Api<ProvinceDTO>(200, dto, "Success", null);

            return Ok(result);
        }
        [HttpGet("district")]
        public ActionResult<Api<List<DistrictDTO>>> GetAllDistrict(//
                                                              [FromQuery(Name = "page"), DefaultValue(1)] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                              )
        {

            int totalItems = _districtService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<DistrictDTO> dtos = _districtService.FindAll(page, limit);

            Api<List<DistrictDTO>> result = new Api<List<DistrictDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }
        [HttpPost("district")]
        public ActionResult<Api<DistrictDTO>> AddDistrict(DistrictEntity district)
        {
            DistrictDTO dto = _districtService.Save(district);

            Api<DistrictDTO> result = new Api<DistrictDTO>(200, dto, "Success", null);

            return Ok(result);
        }
        [HttpGet("ward")]
        public ActionResult<Api<List<WardDTO>>> GetAllWard(//
                                                              [FromQuery(Name = "page"), DefaultValue(1)] int page,//
                                                              [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                              )
        {

            int totalItems = _wardService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<WardDTO> dtos = _wardService.FindAll(page, limit);

            Api<List<WardDTO>> result = new Api<List<WardDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }
        [HttpPost("ward")]
        public ActionResult<Api<WardDTO>> AddWard(WardEntity ward)
        {
            WardDTO dto = _wardService.Save(ward);

            Api<WardDTO> result = new Api<WardDTO>(200, dto, "Success", null);

            return Ok(result);
        }
        [HttpGet("address")]
        public ActionResult<Api<List<AddressDTO>>> GetAllAddress(//
                                                             [FromQuery(Name = "page"), DefaultValue(1)] int page,//
                                                             [FromQuery(Name = "page_limit"), DefaultValue(10),] int limit//
                                                             )
        {

            int totalItems = _wardService.CountAll();

            int totalPages = (int)Math.Ceiling((double)totalItems / limit);

            List<AddressDTO> dtos = _addressService.FindAll(page, limit);

            Api<List<AddressDTO>> result = new Api<List<AddressDTO>>(200, dtos, "Success", new Paging(page, limit, totalPages, totalItems));

            return Ok(result);
        }
    }
}