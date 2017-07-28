Imports System.ComponentModel.DataAnnotations

Namespace Models
	
	Public Class Cart 
		
		<Key()>
		Public Property RecordId As Integer 
		Public Property CartId As String
		Public Property CourseId As Integer 
		Public Property Count As Integer
		Public Property DateCreated As System.DateTime
		
		Public Overridable Property Course AS Course
		
	End Class
	
End Namespace