"friends/GiftReceivedNotification.res"
{
	styles
	{
		Label
		{
			font-size=14 [$LINUX]
			font-size=16
		}
	}

	"GiftReceivedNotification"
	{
		"ControlName"		"GiftReceivedNotification"
		"fieldName"		"GiftReceivedNotification"
		"xpos"		"0"
		"ypos"		"0"
		"wide"		"240"
		"tall"		"98"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		style="notification"
	}
	"GiftImage"
	{
		"ControlName"		"ImagePanel"
		"fieldName"		"GiftImage"
		"xpos"		"16"
		"ypos"		"16"
		"wide"		"42"
		"tall"		"42"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"gradientVertical"		"0"
		"scaleImage"		"0"
		"image" "graphics/icon_toast_gift"
	}
	"NotificationClickPanel"
	{
		"ControlName"		"CNotificationClickPanel"
		"fieldName"		"NotificationClickPanel"
		"xpos"		"0"
		"ypos"		"0"
		"zpos"		"1"
		"wide"		"64"
		"tall"		"24"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"0"
	}
	"LabelSender"
	{
		"ControlName"		"Label"
		"fieldName"		"LabelSender"
		"xpos"		"64"
		"ypos"		"16"
		"wide"		"172"
		"tall"		"14"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"labelText"		"%name%"
		"textAlignment"		"north-west"
		"wrap"		"0"
		"font"		FriendsSmall
	}
	"LabelInfo"
	{
		"ControlName"		"Label"
		"fieldName"		"LabelInfo"
		"xpos"		"64"
		"ypos"		"30"
		"wide"		"172"
		"tall"		"14"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"labelText"		"#friends_giftreceived_info"
		"textAlignment"		"north-west"
		"wrap"		"0"
		"font"		FriendsSmall
	}
	"DarkenedRegion"
	{
		"controlname"	"imagepanel"
		"fieldname"		"DarkenedRegion"
		"xpos"		"0"
		"ypos"		"74"
		"wide"		"240"
		"tall"		"24"
		"fillcolor"	"Black"
		"zpos"		"-1"
	}
	"LabelHotkey"
	{
		"ControlName"		"Label"
		"fieldName"		"LabelHotkey"
		"xpos"		"0"
		"ypos"		"74"
		"wide"		"240"
		"tall"		"24"
		"AutoResize"		"0"
		"PinCorner"		"0"
		"visible"		"1"
		"enabled"		"1"
		"tabPosition"		"0"
		"paintbackground"		"1"
		"labelText"		"#Friends_InviteNotification_Hotkey"
		"textAlignment"		"center"
		"wrap"		"0"
		"font"		FriendsSmall
	}
}
