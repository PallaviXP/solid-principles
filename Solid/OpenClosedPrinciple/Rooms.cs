namespace Solid.OpenClosedPrinciple
{

  public class Rooms
  {

    public RoomType FindRoom(int noOfAdults, int noOfChildren)
    {
      if (noOfAdults + noOfChildren == 1)
      {
        return RoomType.Standard;
      }

      if (noOfAdults + noOfChildren == 2)
      {
        return RoomType.Delux;
      }

      if ((noOfAdults <= 2 && noOfChildren <= 4)
      || noOfAdults == 4)
      {
        return RoomType.Suite;
      }

      return RoomType.Villa;
    }

  }

  public enum RoomType
  {
    Standard,
    Delux,
    Suite,
    Villa
  }
}