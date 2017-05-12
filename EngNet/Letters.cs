namespace EngNet
{

  /// <summary>
  /// ����� ����� ) ������ ��� ����� � ����� � ��������.
  /// </summary>
  public class Letters
  {
    /// <summary>
    /// ������ �����. ���
    /// </summary>
    public char A;
    /// <summary>
    /// ������ �����. ���
    /// </summary>
    public char B;
    /// <summary>
    /// ������ �����. ���
    /// </summary>
    public char C;
    /// <summary>
    /// ������ �����. ������.
    /// </summary>
    public string SA;
    /// <summary>
    /// ������ �����. ������.
    /// </summary>
    public string SB;
    /// <summary>
    /// ������ �����. ������.
    /// </summary>
    public string SC;


    public string Query;

    public Letters(char a, char b, char c) {
      Setup(a, b, c);
    }

    public Letters(string s) {
      Setup(s);
    }

    private void Setup(string s) {
      char[] ca = s.ToCharArray();
      Setup(ca[0], ca[1], ca[2]);
    }

    private void Setup(char a, char b, char c) {
      this.A = a;
      this.B = b;
      this.C = c;
      this.SA = this.A.ToString();
      this.SB = this.B.ToString();
      this.SC = this.C.ToString();
    }
  }
}