   M S B A M L   `   `   `  ����H  DFileOrganiser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:FileOrganiserFileOrganiser  5   	       FileOrganiser.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:FileOrganiser     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Flow File Organiser��5	   	   $	��450��6%   $	��800��62      MaterialDesignBody#���   5
   	    � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ��5   	   Z� .��5      #  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 15Q�6   ���#1e1e1e$��25q�5   	   .��5   
   �� .+�5      �� $��2q�6   ���#151516$��16q�6?    �� CornerRadius$ 25��6K   ._�5      �  � ColumnDefinitions 5      �� 5      $
��auto �6+   �� 5      �� 5      �� 5      $
��Auto �6+   .+�5      �� $��25(�6"   ���#84E6FF$��
16 16 0 16q�6E   $��0��6Y   $��Flow ��6i   $
��Left=�6v   $��Center=�6�   �� 5      $��25(�6"   
�������$��
0 16 16 16q�6C   $��1��6W   $��	Organiser��6g   $
��Left=�6x   $��Center=�6�   �� 5      -   5        $��CloseBtn��5      $��8q�6-   $��Right=�68   $��3��6T   ��5       Z� ��5!      Z� .��5"      �� $
��auto��6    $��	Close.png��5#      5$      �� 5%      -   5        $��MinimiseBtn��5%      $��8q�60   $��Right=�6;   $��2��6W   ��5&      Z� ��5'      Z� .��5(      �� $
��auto��6    $��Minimise.png��5)      5*      5+      5,      � 5-      $
��auto��6   $��Center=�6     5.      �� 5/      �� 50       � RowDefinitions 52      �� 53      $
��auto �6$   �� 54      .+�56      �� -   5        $��	PathInput��5?      $��0��57      $��1��58      $	��373��59      $��Right=�5:      $��Center=�5;        TBStyle#��[ 5<       �� TextAlignment$
 Left=�5=      $��Center=�5>      5?      �� 5A      $��8q�6   $��1��6$   $��1��64   $
��Left=�5B      $��Center=�5C      ��5A   A   Z� ��6W   Z� .��5D      �� -   5        $��
openDialog��5D      $
��auto��6.   $��options Horizontal.png��5E      	 � ToolTip$	 Browse��5F      5G      �� 5H      $:��4Enter downloads path or browse in file explorer ===>��6   $��Bottom=�5I      ���#fff5J      5K      �� 5N      -   5        
 ��Name$
 SetDownloadsDirBtn��5O   2   ���#151516$
��auto��5N   *   ���#151516$��Center=�5O      $��16q�5P      .��5R      �� $��Set Downloads Folder��6   5S      � 5U      $��16q�6    5V      �� 5W      �� 5X      �� 5Y      �� 5Z      .+�5]      �� -   5        $��Center=�5]      $��Center=�5^      $��1��5_      ���#84E6FF.��5b      �� $��Enable || Disable��6    
���   �$��Center=�6L   $��Center=�6g   5c      �� 5d      -   5         ��Name$ organiserStatusTxt��5d      $��2��68   $��Organiser Disabled��6H   
�������$��Center=�6u   $��Center=�5e      $��20(�69   5f      5g      5h      5i      