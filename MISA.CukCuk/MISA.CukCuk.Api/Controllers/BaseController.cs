﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service;
using MISA.Service.Interfaces;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase
    {
        #region Declare

        private readonly IBaseService<TEntity> _baseService;

        #endregion Declare

        #region Constructor

        public BaseController(IBaseService<TEntity> baseService)
        {
            _baseService = baseService;
        }

        #endregion Constructor

        #region Method

        /// <summary>
        /// GET dữ liệu
        /// </summary>
        /// <returns>dữ liệu</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var serviceResult = _baseService.Get();
            var entities = serviceResult.Data as List<TEntity>;

            return StatusCode(entities.Count == 0 ? 204 : 200, entities);
        }

        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="entity">Thực thể cần thêm</param>
        /// <returns>Response tương ứng cho client(201, 400, ...)</returns>
        /// CreatedBy: DMCUONG (07/02/2021)
        [HttpPost]
        public IActionResult Post(TEntity entity)
        {
            var response = _baseService.Insert(entity);
            return StatusCode(!response.Success
                ? 400
                : (int)response.Data > 0
                    ? 201
                    : 200, response.Data);
        }

        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="entity">Thực thể cần sửa</param>
        /// <param name="id">id của thực thể</param>
        /// <returns>Response tương ứng cho client(200, 400, ...)</returns>
        /// CreatedBy: DMCUONG (08/02/2021)
        [HttpPut("{id}")]
        public IActionResult Put(string id, TEntity entity)
        {
            var response = _baseService.Update(entity, id);
            return StatusCode(!response.Success
                ? 400
                : 200, response.Data);
        }

        /// <summary>
        /// Xoá dữ liệu
        /// </summary>
        /// <param name="id">id của thực thể</param>
        /// <returns>Response tương ứng cho client(200, 400, ...)</returns>
        /// CreatedBy: DMCUONG (08/02/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var response = _baseService.Delete(id);
            return StatusCode(!response.Success
                ? 404
                : 200, response.Data);
        }

        #endregion Method
    }
}