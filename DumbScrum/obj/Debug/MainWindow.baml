   M S B A M L   `   `   `  ����D  @DumbScrum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DumbScrum	DumbScrum  5   	   1clr-namespace:DumbScrum.ViewsDumbScrum.Views  5   	       DumbScrum.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DumbScrum     5   	   /viewsclr-namespace:DumbScrum.Views     5   	   -   5          � Title$  
Dumb Scrum��5	   	   $	��650��5
   	   $
��1200��6   
������� � WindowStyle$ SingleBorderWindow=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � ���	#FFE6E6E6 � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      �� 5      $��25 �6   .+�5   
   � $��0��6   $��0��6   ���	#FF3A3A3A.+�5      �� $��1��6    �� Orientation$ 
Horizontal=�6)   
������ $
��Left=�6[   .+�5      �� -   5         ��Name$ mnuHome��5      
������ $
��10,0q�6Y   ��5      �� 5      $ 
Horizontal=�6%   .+�5      �� -   5         ��Name$ imgLogo��5   $   $��35��65   $��35��6@   �� 5      $��
Dumb Scrum��6(   
�������$��16(�6M   $
��Bold"�6[   $��Center=�6m   5      5      �� 5      -   5        $ mnuMyProjects��5      $��My Projects��60   
�������
������ $��50��6r   $
��10,0q�6~   $��14(�6�   �� 5       -   5        $ mnuBrowseProjects��5       $��Browse Projects��64   
�������
������ $��50��6z   $��14(�6�   $
��10,0q�6�   5!      �� 5"      -   5        $ userBox��5"       � ToolTip$  Click to view/edit profile��6&   $��Right=�6K   
������ 
�������$��Stretch=�6�   $
��10,0q�6�   ��5#      �� 5$      $ 
Horizontal=�6!   .+�5%      A� $��35��6"   $��35��6.   ��5&      �� 5'   "   -   5        
imgPfp��5'   -   5)      �� 5*      -   5         ��Name$ txtDisplayName��5*   $   
�������$��Center=�6y   	 �� Padding$	 10,0,0,0q�6�   $��14(�6�   ��6<   �� *LoggedInUser.DisplayName+6�   5+      5-      5.      �� 5/   
   $��1��6   ��6&   �� *CurrentView+51      52      53      