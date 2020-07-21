CREATE TABLE [dbo].[SalesTaxProducts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](500) NULL,
	[Price] [money] NULL,
	[Quantity] [int] NULL,
	[IsBook] [bit] NULL,
	[IsFood] [bit] NULL,
	[IsMedical] [bit] NULL,
	[IsImported] [bit] NULL,
	[BasePrice] [money] NULL,
	[Tax] [money] NULL,
	[TotalPrice] [money] NULL,
	[LastCalculatedTax] [money] NULL,
	[LastCalculatedTotalPrice] [money] NULL,
 CONSTRAINT [PK_SalesTaxProducts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
