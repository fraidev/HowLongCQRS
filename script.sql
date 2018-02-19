CREATE TABLE [dbo].[Series](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](255) NULL,
	[Produtora] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
))
GO

CREATE TABLE [dbo].[Votos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nota] [int] NULL,
	[Data] [datetime2](7) NULL,
	[SerieId_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) 
GO

ALTER TABLE [dbo].[Votos]  WITH CHECK ADD  CONSTRAINT FK_Votos_Series FOREIGN KEY([SerieId_id])
REFERENCES [dbo].[Series] ([Id])
GO

ALTER TABLE [dbo].[Votos] CHECK CONSTRAINT FK_Votos_Series 
GO

create view SerieView as
select s.Id
     , s.Nome
	 , s.Produtora
	 , ROUND(AVG(CAST(Nota AS FLOAT)), 2) as MediaNota -- calcular a media das notas
  from series s 
  inner join Votos v on (s.Id = v.SerieId_id) -- Juntar tabela serie com voto
  group by s.Id, s.Nome, s.Produtora -- agrupar pelos dados comuns
GO




















select * from series

select * from serieview

drop table serieview


alter view SerieView as
select s.Id
     , s.Nome
	 , s.Produtora
	 , ROUND(AVG(CAST(Nota AS FLOAT)), 2) as MediaNota -- calcular a media das notas
  from series s 
  inner join Votos v on (s.Id = v.SerieId_id) -- Juntar tabela serie com voto
  group by s.Id, s.Nome, s.Produtora -- agrupar pelos dados comuns


   insert into Series (Nome, Produtora) values ('Breaking Bad', 'Sony')

   select * from series

  insert into Votos (Nota, Data, SerieId_id) values ( 8, getdate(), 1)


  insert into Votos (Nota, Data, SerieId_id) values ( 10, getdate(), 2)
  insert into Votos (Nota, Data, SerieId_id) values ( 9, getdate(), 2)




select top 5 * 
  from SerieView
order by MediaNota desc, Nome asc

