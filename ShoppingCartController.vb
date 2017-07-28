Imports MvcArtProgramVB.Models
Imports MvcArtProgramVB.ViewModels

Namespace Controllers
    Public Class ShoppingCartController
        Inherits System.Web.Mvc.Controller

        Private storeDB As ArtProgramEntities = New ArtProgramEntities

        '
        ' GET: /ShoppingCart

        Function Index() As ActionResult
            Dim cart = ShoppingCart.GetCart(HttpContext)

            Dim viewModel = New ShoppingCartViewModel With {
                .CartItems = cart.GetCartItems,
                .CartTotal = cart.GetTotal
            }

            Return View(viewModel)
        End Function

        '
        ' GET: /ShoppingCart/AddToCart/5

        Function AddToCart(ByVal id As Integer) As ActionResult
        Dim addedCourse = storeDB.Course.Single(Function(course) course.CourseId = id)

            Dim cart = ShoppingCart.GetCart(HttpContext)

            cart.AddToCart(addedCourse)

            Return RedirectToAction("Index")
        End Function

        '
        ' AJAX: /ShoppingCart/RemoveFromCart/5

        <HttpPost()>
        Public Function RemoveFromCart(ByVal id As Integer) As ActionResult
            Dim cart = ShoppingCart.GetCart(HttpContext)

            Dim courseName = storeDB.Carts.Single(Function(item) item.CourseId = id).Course.CourseName

            Dim itemCount = cart.RemoveFromCart(id)

            Dim results = New ShoppingCartRemoveViewModel With {
                    .Message = Server.HtmlEncode(courseName) &
                    " has been removed from your shopping cart.",
                .CartTotal = cart.GetTotal,
                .CartCount = cart.GetCount,
                .ItemCount = itemCount,
                .DeleteId = id
            }

            Return Json(results)
        End Function

        '
        ' GET: /ShoppingCart/CartSummary

        <ChildActionOnly()>
        Public Function CartSummary() As ActionResult
            Dim cart = ShoppingCart.GetCart(HttpContext)

            ViewBag.CartCount = cart.GetCount

            Return PartialView("CartSummary")
        End Function
    End Class
End Namespace
