using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClientLib
{
    /// <summary>
    /// JSON Format Body : RecipeInfo Request
    /// </summary>
    public class _jsonRecipeInfoRequest : _recipe_data
    {
        public _jsonRecipeInfoRequest() { }
        ~_jsonRecipeInfoRequest() { }
    }


    /// <summary>
    /// JSON Format Body : RecipeInfo Response
    /// </summary>
    public class _jsonRecipeInfoResponse : _recipe_data
    {
        public _jsonRecipeInfoResponse() { }
        ~_jsonRecipeInfoResponse() { }

        public List<_recipe_data> DATA;
    }

}
