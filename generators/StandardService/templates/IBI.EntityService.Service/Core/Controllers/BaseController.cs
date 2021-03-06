﻿using IBI.<%= Name %>.Service.Core.Entities;
using IBI.<%= Name %>.Service.Core.Models;
using IBI.<%= Name %>.Service.Core.Repositories.Interfaces;
using IBI.<%= Name %>.Service.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Web.Http;

// Created by Genie <%= TodaysDate %> by verion <%= Version %>
namespace IBI.<%= Name %>.Service.Core.Controllers
{
    /// <summary>
    /// Controller for every entity
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    [Route("api/{controller}"), Authorize()]
    public partial class BaseController<TService, TRepository, TEntity, TPrimaryKey> : ApiController
        where TEntity : Entity<TPrimaryKey>
        where TRepository : IBaseRepository<TEntity, TPrimaryKey>
        where TService : IBaseService<TRepository, TEntity, TPrimaryKey>
    {
        #region Fields

        /// <summary>
        /// Contains a reference to the service
        /// </summary>
        public TService CurrentService;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseController()
        {
        }

        #endregion Constructors

        #region Get

        /// <summary>
        /// Returns page from the database of a specific size filtering on specific database that is passed
        /// into the request by the AdvancedPageModel in the request body
        /// </summary>
        /// <param name="id">Used to help create a different route and for the most part be ignored</param>
        /// <param name="model">The model containing the advanced paging options</param>
        /// <returns>A PaginationResult that contains the entities</returns>
        [HttpPost(), Route("api/{controller}/AdvancedPage/{id}/")]
        public virtual PaginationResult<TEntity> AdvancedPage(int id, [FromBody] AdvancedPageModel model)
        {
            try
            {
                var pageResult = this.CurrentService.GetAdvancedPage(model);
                return pageResult;
            }
            catch (Exception ex)
            {
                //return
                throw ex;
            }
        }

        /// <summary>
        /// Returns a single entity by the primary key value
        /// </summary>
        /// <param name="id">The value of the primary key of an Entity</param>
        /// <returns>A single entity</returns>
        [HttpGet(), Route("api/{controller}/{id}")]
        public virtual TEntity Get(TPrimaryKey id)
        {
            try
            {
                var entity = this.CurrentService.Get(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns all of the entities from a given database view or table
        /// </summary>
        /// <returns>A list of all of the entities</returns>
        [HttpGet(), Route("api/{controller}/")]
        public virtual List<TEntity> Get()
        {
            try
            {
                var allentities = this.CurrentService.Get();
                return allentities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Returns page from the database of a specific size
        /// </summary>
        /// <param name="limit">The number of records to return</param>
        /// <param name="offset">The row number to offset the return limit</param>
        /// <param name="search">The search term to search the entity's searchable properties</param>
        /// <param name="sort">The property name to sort the return</param>
        /// <param name="sortOrder">The order to sort (descending/ascending) defaults to descending</param>
        /// <returns>A PaginationResult that contains the entities</returns>
        [HttpGet(), Route("api/{controller}/GetPage")]
        public virtual PaginationResult<TEntity> GetPage(int limit, int offset, string search = null, string sort = null, string sortOrder = "desc")
        {
            try
            {
                var pageResult = this.CurrentService.GetAdvancedPage(new AdvancedPageModel()
                {
                    SearchLimit = limit,
                    SearchOffSet = offset,
                    SearchString = search,
                    SortOrder = sortOrder,
                    SortString = sort
                });
                return pageResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Get

        #region Delete Actions

        /// <summary>
        /// Will delete an entity from the database by the primary key value
        /// </summary>
        /// <param name="id">The value of the primary key of an Entity</param>
        /// <returns>The entity that is removed from the database</returns>
        [HttpDelete(), Route("api/{controller}/{id}")]
        public virtual TEntity Delete(TPrimaryKey id)
        {
            try
            {
                var entity = this.CurrentService.Get(id);
                this.CurrentService.Delete(id);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Delete Actions

        #region Post Actions

        /// <summary>
        /// Inserts an entity to the database that passed from the request body
        /// </summary>
        /// <param name="entity">The entity to add to the database</param>
        /// <returns>The entity after it's inserted into the database</returns>
        [HttpPost(), Route("api/{controller}/")]
        public virtual TEntity Post([FromBody]TEntity entity)
        {
            try
            {
                this.CurrentService.Insert(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Post Actions

        #region Put Actions

        /// <summary>
        /// Updates an entity in the database by the primary key and the entity that
        /// passed into the request in the request body
        /// </summary>
        /// <param name="id">The primary key</param>
        /// <param name="entity">The entity that is passed into the request by the body</param>
        /// <returns>The entity after it's updated</returns>
        [HttpPut(), Route("api/{controller}/{id}")]
        public virtual TEntity Put(int id, [FromBody]TEntity entity)
        {
            try
            {
                this.CurrentService.Update(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Put Actions

        #region AutoComplete

        /// <summary>
        /// Gets an auto complete list based on the length of the number of results you want to return
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"><see cref="AutoComplete"/></param>
        /// <returns>A list of entity</returns>
        [HttpPost(), Route("api/{controller}/GetAutoComplete/{id}")]
        public virtual List<TEntity> GetAutoComplete(int id, [FromBody] AutoComplete model)
        {
            try
            {
                var results = this.CurrentService.GetAutocomplete(model.Length, model.SearchTerm);
                return results;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion AutoComplete
    }
}