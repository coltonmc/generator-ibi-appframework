﻿using System.Collections.Generic;

namespace IBI.<%= Name %>.Service.Core.Models
{
    /// <summary>
    /// Created by Genie 2018-04-04, 02:18 PM by verion 1.1.25
    /// A model that represents how to filter the entity in Advanced Paging
    /// </summary>
    public class AdvancedSearch
    {
        #region Enums

        /// <summary>
        /// How to advanced search
        /// </summary>
        public enum AdvancedSearchType
        {
            /// <summary>
            /// Between
            /// </summary>
            Between = 0,

            /// <summary>
            /// Not Equal
            /// </summary>
            NotEqual = 1,

            /// <summary>
            /// Equal
            /// </summary>
            Equal = 2,

            /// <summary>
            /// Less than
            /// </summary>
            LessThan = 3,

            /// <summary>
            /// Less than or equal
            /// </summary>
            LessThanEqual = 4,

            /// <summary>
            /// Greater than
            /// </summary>
            GreaterThan = 5,

            /// <summary>
            /// Greater than or equal
            /// </summary>
            GreaterThanEqual = 6,

            /// <summary>
            /// Like query
            /// </summary>
            Like = 7,

            /// <summary>
            /// In Clause
            /// </summary>
            In = 8,

            /// <summary>
            /// Is Null
            /// </summary>
            IsNull = 9,

            /// <summary>
            /// Is Not Null
            /// </summary>
            IsNotNull = 10,

            /// <summary>
            /// Not Like
            /// </summary>
            NotLike = 11,

            /// <summary>
            /// Not In
            /// </summary>
            NotIn = 12
        };

        #endregion Enums

        #region Properties

        /// <summary>
        /// Used for int values because for some reason
        /// an int value on one side would convert to a long
        /// here and thus causing issues
        /// </summary>
        public int? IntValue { get; set; }

        /// <summary>
        /// List of values to filter using the "in" clause
        /// </summary>
        public List<object> ListValue { get; set; }

        /// <summary>
        /// The name of the entity property to filter
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// How to filter the entity
        /// </summary>
        public AdvancedSearchType TypeOfSearch { get; set; }

        /// <summary>
        /// The value to filter the entity
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Only should be set for between functionality
        /// </summary>
        public object Value2 { get; set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Creates an empty AdvancedSearch
        /// </summary>
        public AdvancedSearch()
        {
        }

        /// <summary>
        /// Create an AdvancedSearch by the property name, how to filter the data and values to filter the data
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="type">How to query the data</param>
        /// <param name="valueA">The value to query</param>
        /// <param name="valueB">A second value to query for the "Between" filter</param>
        public AdvancedSearch(string propertyName, AdvancedSearchType type, object valueA, object valueB)
        {
            this.PropertyName = propertyName;
            this.TypeOfSearch = type;
            if (valueA.GetType() == typeof(int) || valueA.GetType() == typeof(int?))
            {
                this.IntValue = (int?)valueA;
            }
            else
            {
                this.Value = valueA;
            }
            this.Value2 = valueB;
        }

        /// <summary>
        /// Creates an AdvancedSearch by the name of the property to search, how to filter
        /// the property and a list of values
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="type">How to query the data</param>
        /// <param name="values">The values to filter the property on</param>
        public AdvancedSearch(string propertyName, AdvancedSearchType type, List<object> values)
        {
            this.PropertyName = propertyName;
            this.TypeOfSearch = type;
            this.ListValue = values;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Create a "Between" query
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value of the left side of the Between filter</param>
        /// <param name="b">The value of the right side of the Between filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch Between(string propertyName, object a, object b)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.Between, a, b);
        }

        /// <summary>
        /// Creates an "Equal To (=)" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch Equal(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.Equal, a, null);
        }

        /// <summary>
        /// Creates an "Greater than (>)" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch GreaterThan(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.GreaterThan, a, null);
        }

        /// <summary>
        /// Creates an "Greater than or equal (>=)" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch GreaterThanOrEqualTo(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.GreaterThanEqual, a, null);
        }

        /// <summary>
        /// Creates an "IN clause IN(a,b,c....,etc)" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch In(string propertyName, List<object> a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.In, a);
        }

        /// <summary>
        /// Creates a "IS NOT NULL" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch IsNotNull(string propertyName)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.IsNotNull, null, null);
        }

        /// <summary>
        /// Creates a "IS NULL" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch IsNull(string propertyName)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.IsNull, null, null);
        }

        /// <summary>
        /// Creates a "Less than" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch LessThan(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.LessThan, a, null);
        }

        /// <summary>
        /// Creates a "Less than or equal" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch LessThanOrEqualTo(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.LessThanEqual, a, null);
        }

        /// <summary>
        /// Creates a "Like (%a%)" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch Like(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.Like, a, null);
        }

        /// <summary>
        /// Creates a "Not Equal (!=)" filter
        /// </summary>
        /// <param name="propertyName">The name of the entity property to query</param>
        /// <param name="a">The value to filter</param>
        /// <returns>AdvancedSearch</returns>
        public static AdvancedSearch NotEqual(string propertyName, object a)
        {
            return new AdvancedSearch(propertyName, AdvancedSearchType.NotEqual, a, null);
        }

        #endregion Methods
    }
}