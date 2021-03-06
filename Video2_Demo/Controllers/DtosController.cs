﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Video2_Demo.Models;

namespace Video2_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtosController : ControllerBase
    {

        private readonly IMapper _mapper;
        public DtosController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route(nameof(GetGoodsList))]
        public async Task<List<dynamic>> GetGoodsList()
        {
            //模拟数据
            var allGoodsList = new List<GoodsEntity>();

            var goodsList = new List<GoodsEntity>() {
                new GoodsEntity(){
                    Id =1,
                    Brands=new BrandsEntity(){
                        Id=111,
                        Name="Lining"
                    },
                    Name ="商品1",
                    Price =23.25M,
                    CreateTime =DateTime.Now,
                    IsDeleted =true,
                    Items =new List<Items> (){
                        new Items (){ Id=11,Name="apple"}
                    }
                },
                new GoodsEntity(){
                    Id =2,
                    Brands=new BrandsEntity(){
                        Id=111,
                        Name="耐克"
                    },
                    Name ="商品2",
                    Price =21.25M,
                    CreateTime =DateTime.Now
                },
                new GoodsEntity(){
                    Id =3,
                    Brands =null,
                    Name ="商品3",
                    Price =20.25M,
                    CreateTime =DateTime.Now
                },
                new GoodsEntity(){
                    Id =4,
                    Brands =new BrandsEntity(){
                        Id=111,
                        Name="New Balance"
                    },
                    Name ="商品4",
                    Price =19.25M,
                    CreateTime =null
                },
            };

            allGoodsList = goodsList;

            for (int i = 0; i < 2000; i++)
            {
                allGoodsList.AddRange(goodsList);
            }

            //对象集合转Dto集合.
            var goodsDtos = _mapper.Map<List<GoodsDto>>(allGoodsList);
            //var goodsDtos2 = (goodsList.AsQueryable()).ProjectTo<GoodsDto>(_mapper.ConfigurationProvider);

            return new List<dynamic> {
                goodsDtos,
                //goodsDtos2
            };
        }
















        // GET: api/Dtos
        [HttpGet]
        public GoodsDto Get()
        {
            GoodsEntity goodsEntity = new GoodsEntity() {
                Name="apple",
                Price=22,
                Id=6,
                CreateTime=DateTime.Now
            };
            // 属性很多，赋值麻烦
            // 修改业务逻辑
            GoodsDto goodsDto = new GoodsDto() {
                GoodsName=goodsEntity.Name,
                Price = goodsEntity.Price,
            };
            return goodsDto ;
        }

        // GET: api/Dtos/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Dtos
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Dtos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
