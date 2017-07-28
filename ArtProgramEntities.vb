Imports System.Data.Entity

Namespace Models
	Public Class ArtProgramEntities
		Inherits DbContext
	
		Public Property Course As DbSet(Of Course)
		Public Property Discipline As DbSet(Of Discipline)
		Public Property Professor As DbSet(Of Professor)
		Public Property Carts As DbSet(Of Cart)
		Public Property Order As DbSet(Of Order)
		Public Property OrderDetails As DbSet(Of OrderDetail)
		
	End Class 
End Namespace
	
	