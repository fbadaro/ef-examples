using System.ComponentModel.DataAnnotations;

public enum EnumTestOne
{
  OptionA,
  OptionB,
  OptionC,
}

public enum EnumTestTwo
{
  [Display(Name = "OptionA")]
  OptionA,

  [Display(Name = "OptionB")]
  OptionB,

  [Display(Name = "OptionC")]
  OptionC
}

public enum EnumTestThree
{
  [Display(Name = "A")]
  OptionA,

  [Display(Name = "B")]
  OptionB,

  [Display(Name = "C")]
  OptionC
}

public enum EnumTestFour
{
  AOption = 'A',
  BOption = 'B',
  COption = 'C'
}