@ModelType MvcArtProgramVB.ViewModels.ShoppingCartViewModel

@Code
   ViewBag.Title = "Shopping Cart"
End Code

<script type="text/javascript">
   $(function () {
       // Document.ready -> link up remove event handler
       $(".RemoveLink").click(function () {
           // Get the id from the link
           var recordToDelete = $(this).attr("data-id");

           if (recordToDelete != '') {

               // Perform the ajax post
               $.post("/ShoppingCart/RemoveFromCart", { "id": recordToDelete },
                   function (data) {
                       // Successful requests get here
                       // Update the page elements
                       if (data.ItemCount == 0) {
                           $('#row-' + data.DeleteId).fadeOut('slow');
                       } else {
                           $('#item-count-' + data.DeleteId).text(data.ItemCount);
                       }

                       $('#cart-total').text(data.CartTotal);
                       $('#update-message').text(data.Message);
                       $('#cart-status').text('Cart (' + data.CartCount + ')');
                   });
           }
       });

   });


   function handleUpdate() {
       // Load and deserialize the returned JSON data
       var json = context.get_data();
       var data = Sys.Serialization.JavaScriptSerializer.deserialize(json);

       // Update the page elements
       if (data.ItemCount == 0) {
           $('#row-' + data.DeleteId).fadeOut('slow');
       } else {
           $('#item-count-' + data.DeleteId).text(data.ItemCount);
       }

       $('#cart-total').text(data.CartTotal);
       $('#update-message').text(data.Message);
       $('#cart-status').text('Cart (' + data.CartCount + ')');
   }
</script>
<h3>
   <em>Review</em> your cart:
</h3>
<p class="button">
   @Html.ActionLink("Checkout >>", "AddressAndPayment", "Checkout")
</p>
<div id="update-message">
</div>
<table>
   <tr>
       <th>
           Course Name
       </th>
       <th>
           Fee (each)
       </th>
       <th>
           Quantity
       </th>
       <th></th>
   </tr>
   @For Each item In Model.CartItems
       @<tr id="row-@item.CourseId">
           <td>
               @Html.ActionLink(item.Course.CourseName, "Details", "Store", New With {.id = item.CourseId}, Nothing)
           </td>
           <td>
               @item.Course.Fee
           </td>
           <td id="item-count-@item.CourseId">
               @item.Count
           </td>
           <td>
               <a href="#" class="RemoveLink" data-id="@item.CourseId">Remove from cart</a>
           </td>
       </tr>
   Next
   <tr>
       <td>
           Total
       </td>
       <td>
       </td>
       <td>
       </td>
       <td id="cart-total">
           @Model.CartTotal
       </td>
   </tr>
</table>