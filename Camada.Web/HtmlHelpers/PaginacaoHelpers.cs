using System;
using System.Web.Mvc;
using Camada.Web.Models;
using System.Text;

namespace Camada.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        public static MvcHtmlString Pagelinks(this HtmlHelper Html, Paginacao Paginacao, Func<int, string> PaginaUrl)
        {
            StringBuilder Resultado = new StringBuilder();

            for (int i = 1; i <= Paginacao.TotalPagina; i++)
            {
                TagBuilder Tag = new TagBuilder("a");
                Tag.MergeAttribute("href", PaginaUrl(i));
                Tag.InnerHtml = i.ToString();

                if (i == Paginacao.PaginaAtual)
                {
                    Tag.AddCssClass("selected");
                    Tag.AddCssClass("btn-primary");
                }
                Tag.AddCssClass("btn btn-default");
                Resultado.Append(Tag);
            }

            return MvcHtmlString.Create(Resultado.ToString());
        }
    }
}