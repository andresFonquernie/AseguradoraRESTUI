   M S B A M L   `   `   `  ����L  HAseguradoraRESTUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:AseguradoraRESTUIAseguradoraRESTUI  5   	       AseguradoraRESTUI.Bills   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:AseguradoraRESTUI     5   	     � Title$  Bills��5   	   $
��Auto��6   $
��Auto��6%   .��5	      �� .+�5
   
   �� $
��Auto��6   $
��Auto��6"   .+�5      �� $��Search��6   $��16(�6&   $��
20,20,20,0q�64   6J   � 5       � ColumnDefinitions 5      �� 5      $
��Auto �6'   66   �� 5      $��* �6'   63   �� 5      $
��Auto �6'   66   �� 5      $
��Auto �6'   66   �� 5      $��4* �6'   64   .+�5      �� -   5         ��Name$ TxtId��5      $��0��6+   $��
20,10,20,0q�6;   ID:6T   �� 5      -   5         ��Name$ TxtBoxSearch��5   *   $��1��6   $��	0,10,10,0q�6@   $��Right=�6S   $	��100��6o   6}   �� 5      -   5         ��Name$ 	BtnSearch��5   )   $��2��6   $��10,0,0,0q�6<   .��6c   Search6k   �� 5      -   5        $ BtnAll��5   )   $��3��6   $��	10,0,20,0q�69   .��6^   All6c   5      5      �� 5   
   $
��Auto��6   $
��Auto��6"   .+�5      �� $��Bills��6   $��16(�6%   $��	20,20,0,0q�63   6H   ,� 5      -   5        $��Table��5   '   " ,� VerticalScrollBarVisibility$ Hidden=�64   $	��300��6Y   $ ,� HorizontalScrollBarVisibility$ Disabled=�6i   .��5      /� .T�5      �� -   5         �Name$ 
TableBills��5       �� Columns 5       �� 5!      -   5        $ Client��5!   *   6:   �� 5"      -   5        $ Id��5"   *   66   �� 5#      -	   5        $ Money��5#   *   69   .�5%      �� .�5&      �� 
�������.�5'   "   �� 	 �� 
ColumnSpan$	 1��6,   
 �� BorderBrush

 �   � �� TextAlignment$ Center=�6O   .�5(   &   J� .*�60   Client68   5)   #   �� 5*   "   $	 1��6,   $ Center=�6;   .�5+   &   J� .*�60   ID64   5,   #   �� 5-   "   $	 1��6,   $ Center=�6;   .�5.   &   J� .*�60   Money to pay6>   5/   #   50      51      52      53      54      � 55      $��
20,20,20,0q�6    56      �� 57      $��2* �6'   65   �� 58      $��* �6'   63   �� 59      $��* �6'   63   .+�5;      �� -
   5        $ BtnBills��5;      $��1��6+   $
��10,0q�6;   $��Bills��6[   �� 5<      -   5        $ 	BtnEditar��5<      $��2��6,   {�.  .��6f   Edit6l   5=      5>      �� 5@   
   $��	20,20,0,0q�6   .+�5A      �� $��16(�6   �� 6'   $�Create ��6+   �� 6<   $
�bill��6@   �� 6N   �� 6Z   6a   � 5B       5C      �� 5D      $
��Auto �6'   66   �� 5E      $��3* �6'   64   �� 5F      $��2* �6'   64    � RowDefinitions 5H      �� 5I      6&   �� 5J      6&   �� 5K      6&   �� 5L      6&   .+�5N      �� $��0��6   $��	ID Client��6,   $��0��6=   $��	0,10,20,0q�6J   $��18��6]   $	��Top=�6i   6�   �� 5O      $��0��6   $��Money to pay��6,   $��2��6@   $��	0,10,20,0q�6M   6b   �� 5P      -   5        $ TxtBoxIdClient��5P   7   $��1��6   $��0��6*   $��	0,10,20,0q�6O   6d   �� 5Q      -   5        $ TxtBoxMoney��5Q   7   $��1��6   $��2��6*   $��	0,10,20,0q�6L   6a   �� 5R      -   5        $ 	BtnEnviar��5R   6   $��1��6   $��4��6)   $��	0,10,20,0q�6I   .��6q   Send6w   5S      5T      �� 5V   
   .+�5W      � $��	0,20,20,0q�6    5X      �� 5Y      $��3* �6'   64   �� 5Z      $
��Auto �6'   66   �� 5[      $
��Auto �6'   66   �� 5\      $
��Auto �6'   66   .+�5^      �� -   5        $ 
BtnWnBills��5^   )   $��1��6   $��Bills��6=   {�.  6M   �� 5_      -   5        $ BtnWnClients��5_   )   $��2��6   $��Clients��6?   $
��10,0q�6Q   6_   �� 5`      -   5        $ BtnWnContracts��5`   )   $��3��6   $��	Contracts��6A   $��10,0,0,0q�6U   6g   5a      5b      5c      5d      