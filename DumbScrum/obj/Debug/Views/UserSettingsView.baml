   M S B A M L   `   `   `  ����D  @DumbScrum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:DumbScrum.ViewsDumbScrum.Views  5      &     DumbScrum.Views.UserSettingsView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:DumbScrum.Views     5      -   5        .��5	      � 
�������  � RowDefinitions  5
   
   �� 5      $��50 �6   �� 5      �� 5      $��60 �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $��User Settings:��6   $
��Bold"�6-   $��16(�6?   $��Center=�6M   $��	10,10,0,0q�6h   �� 5      $"��Manage your account settings��6   $
��10,0q�6;   5      �� 5   
   -   5         ��Name$ 
btnSignOut��5      $��Sign Out��6%   $��Right=�68   $��Center=�6T   $
��10,5q�6o   $��10q�6~   6�   �� 5   
   $��Bottom=�6   � 5   
   $��1��6   $��10q�6     5      �� 5      $��60 �6    �� 5      $��60 �6    �� 5      .+�5      �� $ 
Horizontal=�6   $��Center=�62   .+�5      �� $��Profile Picture:��6   $��Center=�63   $��DemiBold"�6N   A� 5      $��60��6   $��60��6&   $
��10,0q�61   ��5      �� 5      -   5        
imgPfp��5   %   5!      �� 5"      -   5        $ btnChangePfp��5"      $��Change Profile Picture��6/   $��25��6P   $	��5,0q�6\   6j   5#      �� 5%      $ 
Horizontal=�6   $��Center=�62   $��1��6M   .+�5&      �� $��Display Name: ��6   $��Center=�61   $��DemiBold"�6L   �� 5'      -   5         ��Name$ tbDisplayName��5'      $	��300��61   $��Center=�6=   $��4q�6X   5(      � 5)      $��2��6     5*      �� 5+      $��30 �6$   �� 5,      .+�5.      �� $��Change Password: ��6   $��Center=�64   $��DemiBold"�6O   �� 5D      -   5        $ btnChangePassword��5D      $��Change Password��64   $��2��6N   $
��Left=�6[   $	��Top=�6v   $��5q�5E      6%   5F      5G      �� 5H   
   $ 
Horizontal=�6   $��2��6.   $��Bottom=�6;   $��Right=�6V   .+�5I      �� -   5        $ btnSave��5I      $��Save Changes��6&   $
��10,5q�6=   $��	0,0,10,10q�6L   6_   5J      5K      5L      