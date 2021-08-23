create Procedure Retrievedata2
(
   @FirstName varchar(100),
  @LastName varchar(100),
  @Age int,
  @Country varchar (100),
  @PhoneNumber bigint,
  @Email varchar(200)
)
As
Begin
--Select *from Spotify_Table ;
select count(FirstName) from Spotify_table group by Country;
--select FirstName from Spotify_Table where Country=@Country;
--select * from Spotify_Table where FirstName=@FirstName;
End