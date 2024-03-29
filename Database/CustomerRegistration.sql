USE [CustomerRegistrationDB]
GO
/****** Object:  Table [dbo].[CustomerInfo]    Script Date: 2022/02/08 00:33:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerInfo](
	[CustomerId] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerPNum] [nvarchar](15) NULL,
	[CustomerAddress] [nvarchar](200) NULL,
	[CustomerEmail] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_CustomerInfo] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CustomerInfo] ON 

INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2039, N'Pasindu', N'0710333214', N'154/B Weedagama Bandaragama', N'pasindumadushan7@gmail.com', 1)
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2040, N'Lahiru', N'0710324687', N'158/B Weedagama Bandaragama', N'lahiruroshan7@gmail.com', 1)
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2041, N'Niwantha', N'0710333214', N'145/E Malamulla Panadura', N'Nuwantha7@gmail.com', 1)
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2042, N'KamalP', N'0715467895', N'155/A Kaluthara South Kaluthara', N'kamal7@gmail.com', 1)
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2043, N'new', N'03855555', N'new', N'new@gamai.cl', 0)
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2044, N'Saman', N'0382291709', N'sdfsdf', N'Saman56@gmail.com', 0)
INSERT [dbo].[CustomerInfo] ([CustomerId], [CustomerName], [CustomerPNum], [CustomerAddress], [CustomerEmail], [IsActive]) VALUES (2045, N'Nimal', N'0718344054', N'021/A Bandaragama Bandaragama', N'Nimal@gmail.com', 1)
SET IDENTITY_INSERT [dbo].[CustomerInfo] OFF
/****** Object:  StoredProcedure [dbo].[GetCustomerInfo]    Script Date: 2022/02/08 00:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pasindu Madushan>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCustomerInfo]
(
	@Action nvarchar(10) = null,
	@CustomerId int = null,
	@CustomerName nvarchar(30)= null
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF @Action = 'ALL'
	BEGIN
		SELECT CustomerId, CustomerName, CustomerPNum, CustomerAddress, CustomerEmail FROM CustomerInfo
		WHERE IsActive = 1
	END

	ELSE IF @Action = 'FIND'
	BEGIN
		SELECT CustomerId, CustomerName, CustomerPNum, CustomerAddress, CustomerEmail FROM CustomerInfo 
		WHERE CustomerId = @CustomerId AND IsActive = 1
	END

	ELSE IF @Action = 'FINDBYNAME'
	BEGIN
		SELECT CustomerId, CustomerName, CustomerPNum, CustomerAddress, CustomerEmail FROM CustomerInfo 
		WHERE UPPER(CustomerName) LIKE '%' + UPPER(@CustomerName) + '%' AND IsActive = 1
	END

END
GO
/****** Object:  StoredProcedure [dbo].[SetCustomerInfo]    Script Date: 2022/02/08 00:33:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Pasindu Madushan>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SetCustomerInfo]
(
	@Action nvarchar(10) = null,
	@CustomerId int = null,
	@CustomerName nvarchar(50) = null,
	@CustomerPNum nvarchar(15) = null,
	@CustomerAddress nvarchar(200) = null,
	@CustomerEmail nvarchar(50) = null
)	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	begin try
			begin transaction t1;
			-- Insert statements for procedure here
			IF @Action = 'INSERT'
			BEGIN
				INSERT INTO [dbo].[CustomerInfo]
				([CustomerName]
				,[CustomerPNum]
				,[CustomerAddress]
				,[CustomerEmail]
				,[IsActive])
				VALUES
				(@CustomerName,
				@CustomerPNum,
				@CustomerAddress,
				@CustomerEmail
				,1)

				SELECT 'Successfully saved!' as outputInfo,0 as rsltType;
			END

			ELSE IF @Action = 'UPDATE'
			BEGIN

				UPDATE [dbo].[CustomerInfo]
				SET 
				[CustomerName] = @CustomerName,
				[CustomerPNum] = @CustomerPNum,
				[CustomerAddress] = @CustomerAddress,
				[CustomerEmail] = @CustomerEmail

				WHERE CustomerId = @CustomerId

				SELECT 'Successfully saved!' as outputInfo,0 as rsltType;

			END

			ELSE IF @Action = 'DELETE'
			BEGIN
				UPDATE [dbo].[CustomerInfo]
				SET
				[IsActive] = 0
			
				WHERE CustomerId = @CustomerId

				SELECT 'Successfully deleted!' as outputInfo,0 as rsltType;
			END
	
			commit transaction t1;
	end try
		begin catch
			rollback transaction t1;
			declare @errorMsgSv nvarchar(max)=null;
			set @errorMsgSv = ERROR_MESSAGE();
			select @errorMsgSv as outputInfo,1 as rsltType;
			
		end catch

END
GO
