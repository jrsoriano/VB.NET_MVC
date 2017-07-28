Imports System.ComponetModel
Imports System.ComponetModel.DataAnnotations
Imports System.Web.Mvc

Namespace Models
	
	<Bind(Exclude: = "CourseId")>
		
		Public Class Course
			<ScaffoldColumn(False)>
			Public Property CouseId As Integer
			<DisplayName("Discipline")>
			Public Property DiciplineId As Integer
			<DisplayName("Professor")>
			Public Property ProfessorId As Integer
			<Required(ErrorMessage:= "A Course Name is required")>
			<StringLength(160)>
			Public Property CourseName As String
			<Required(ErrorMessage:= "Fee is required")>
			<Range(0.01, 100, ErrorMessage:= "Price must be between 0.01 and 100.00")>
			Public Property Fee as Decimal
		
			Public Overridable Property Dicipline AS Dicipline
			Public Overridable Property Professor AS Professor
			Public Overridable Property OrderDetails AS List(Of OrderDetails)
		
		End Class
End Namespace		
			
			
			
			
	
