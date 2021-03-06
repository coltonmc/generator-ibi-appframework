using IBI.<%= projectname %>.Application.Models.Entities;
using IBI.<%= projectname %>.Application.Models;
using System.Collections.Generic;

/// <summary>
/// Created by Genie - Entity Scaffolding on <%= TodaysDate %> by verion <%= Version %>
/// </summary>
namespace IBI.<%= projectname %>.Application.Services.Interfaces
{
    public interface I<%= entityinfo.PropertyName %>Service
    {
        /// <summary>
        /// Get a page of the <%= entityinfo.PropertyName %> entity from the database
        /// with the standard paging
        /// </summary>
        /// <param name="limit">The size of the page</param>
        /// <param name="offset">The row offset</param>
        /// <param name="search">The search string if any</param>
        /// <param name="sort">The name of the property to sort by</param>
        /// <param name="order">The order direction to sort the property (asc/desc)</param>
        /// <returns>PaginationResult of <%= entityinfo.PropertyName %></returns>		
        PaginationResult<<%= entityinfo.PropertyName %>> GetPage(int limit, int offset, string search, string sort, string order);

		/// <summary>
        /// Deletes a(n) <%= entityinfo.PropertyName %> entity from the databaes
        /// </summary>
        /// <param name="Id">The primary key of the <%= entityinfo.PropertyName %> to delete</param>
		void Delete(<%= entityinfo.PrimaryKey %> id);
		
		/// <summary>
        /// Get all of the <%= entityinfo.PropertyName %> entity from the database
        /// </summary>
        /// <returns>List of <%= entityinfo.PropertyName %></returns>
		List<<%= entityinfo.PropertyName %>> Get();

		/// <summary>
        /// Returns a single <%= entityinfo.PropertyName %> entity by it's primary key
        /// </summary>
        /// <returns><%= entityinfo.PropertyName %></returns>
		<%= entityinfo.PropertyName %> Get(<%= entityinfo.PrimaryKey %> id);

		/// <summary>
        /// Gets a page of the <%= entityinfo.PropertyName %> entity with
        /// an advanced query to help filter the data
        /// </summary>
        /// <param name="advancedSearch">List of AdvancedSearch properties</param>
        /// <param name="limit">The size of the page</param>
        /// <param name="offset">The row offset</param>
        /// <param name="search">The search string if any</param>
        /// <param name="sort">The name of the property to sort by</param>
        /// <param name="order">The order direction to sort the property (asc/desc)</param>
        /// <param name="type">Helps with filtering the data further</param>
        /// <returns>PaginationResult of <%= entityinfo.PropertyName %></returns>
		PaginationResult<<%= entityinfo.PropertyName %>> GetAdvancedPage(List<AdvancedSearch> advancedSearch, int limit, int offset, string search = null, string sort = null, string order = null, int type = 0);

		/// <summary>
        /// Inserts a(n) <%= entityinfo.PropertyName %> record to the database and
        /// returns the same entity back with it's new primary
        /// key filled in
        /// </summary>
        /// <param name="entity">The new <%= entityinfo.PropertyName %> record to create</param>
        /// <returns><%= entityinfo.PropertyName %></returns>
		<%= entityinfo.PropertyName %> Insert(<%= entityinfo.PropertyName %> entity);

		/// <summary>
        /// Updates a(n) <%= entityinfo.PropertyName %> record on the database
        /// </summary>
        /// <param name="entity">The <%= entityinfo.PropertyName %> entity to update</param>
		void Update(<%= entityinfo.PropertyName %> entity);
		
		/// <summary>
        /// Returns a list of the <%= entityinfo.PropertyName %> entity by the autocomplete
        /// properties by the term
        /// </summary>
        /// <param name="term">The search term to filter the records of the <%= entityinfo.PropertyName %> entity</param>
        /// <param name="length">The number of records to return</param>
        /// <param name="type">The type to return</param>
        /// <returns>List of <%= entityinfo.PropertyName %></returns>
		List<<%= entityinfo.PropertyName %>> GetAutocomplete(string term, int length = 20, int type = 0);

		/* GENIE HOOK */
        /* DO NOT DELETE THE ABOVE LINE */
    }
}