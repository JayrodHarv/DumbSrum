   M S B A M L   `   `   `  ����D  @DumbScrum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:DumbScrum.ToolWindowsDumbScrum.ToolWindows  5   	   ?$clr-namespace:DumbScrum.UserControlsDumbScrum.UserControls  5   	   /    )DumbScrum.ToolWindows.PlanNewSprintWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:DumbScrum.ToolWindows     5   	   =userControls$clr-namespace:DumbScrum.UserControls     5   	   -   5          � Title$  Plan New Sprint��5	   	   $	��400��6!   $	��600��6.    � WindowStartupLocation$ CenterScreen=�6:    � WindowStyle$ 
ToolWindow=�6_   .��5
      �  � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��50 �6   �� 5      �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��2��6!   $
��Wrap=�65    �� TextAlignment$
 Left=�5      $��14(�6)   $��10,0,0,0q�67   $��SemiBold"�6I   Plan New Sprint5      �� 5   
   $��1��6   .+�5      �� $��Feature:��6   $��DemiBold"�6'   $��10, 0q�6=   $��Center=�6M   �� 5      -   5         ��Name$ 
cboFeature��5      $��DemiBold"�6+   $��25��6A   $��10, 3q�6M   $��Center=�5      $
��Left=�62   ��5      �� 5      .R�5      �� ��6$   �� *Name+5       5"      5#      �� 5%   
   $��1��6   $��1��6"   .+�5&      �� $��Sprint Name:��6   $��DemiBold"�6+   $��10, 0q�6A   $��Center=�6Q   �� 5'      -   5         ��Name$ tbSprintName��5'      $��DemiBold"�6,   $��25��6B   $��10, 3q�6N   $��Center=�5(      $
��Left=�68   5)      � 5+   
   $��2��6   $��0��6    5,      �� 5-      $��30 �6    �� 5.      .+�50      �� $%��Selected Feature User Stories: ��6   $��DemiBold"�6>   $��10, 0q�6T   $��Center=�6d   �� 51      -   5         ��Name$ lvFeatureStories��51      $��1��61   ��52      �� 53      .R�54      .   (DumbScrum.UserControls.UserStoryListItem  55      57      58      � 5:   
   $��2��6   $��1��6    5;      �� 5<      �� 5=      �� 5>      .+�5@      �� $��0��6   $��Center=�6&   .+�5A      �� $��
StartDate:��6   $��DemiBold"�6-   $��10, 0q�6C   $��Center=�6S   (  "System.Windows.Controls.DatePicker  5B      -   5        	  Name$	 dpStartDate��5B      $��DemiBold"�62   $��25��6H   $��10, 3q�6T   $��Center=�5C      $
��Left=�62   5D      �� 5E      $��1��6   $��Center=�6&   .+�5F      �� $��EndDate:��6   $��DemiBold"�6+   $��10, 0q�6A   $��Center=�6Q     5G      -   5        $	 	dpEndDate��5G      $��DemiBold"�60   $��25��6F   $��10, 3q�6R   $��Center=�5H      $
��Left=�62   5I      �� 5J      
 �� Orientation$
 
Horizontal=�6   $��2��62   $��Center=�6?   $��Center=�6\   .+�5K      �� $��Sprint Duration: ��6   �� 5L      -   5         ��Name$ 
lbDuration��5L      5M      5N      �� 5O   
   $��3��6   $��1��6"   $
 
Horizontal=�63   $��Right=�6L   .+�5P      �� -   5         ��Name$ btnPlanSprint��5P      $��Plan Sprint��6,   $��5q�5Q      $��Right=�6   $��DemiBold"�5R      $��10, 3q�5S      6    �� 5T      -	   5        $ 	btnCancel��5T      $��Cancel��6(   $��5q�5U      $��Right=�6   $��DemiBold"�5V      $��10, 3q�5W      6    5X      5Y      5Z      