Namespace Models 
	
	Public Class OrderDetails
		
		Public Property OrderDetailId As Integer
		Public Property OrderId As Integer
		Public Property CourseId As Integer 
		Public Property Quantity AS Integer 
		Public Property UnitFee As Decimal 
		
		Public Overridable Property Course As Course 
		Public Overridable Property Order As Order 
	
	End Class
	
End Namespace
		