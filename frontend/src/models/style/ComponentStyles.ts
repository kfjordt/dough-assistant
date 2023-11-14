import { IStaticElementStyle, ITextStyle, IBorderElementStyle, IIconStyle, IClickableElementStyle } from './ElementStyles';

export interface ICardStyle {
    element: IStaticElementStyle
    text: ITextStyle
    border: IBorderElementStyle
}

export interface IIconCard {
    iconStyle: IIconStyle
    element: IStaticElementStyle
    border: IBorderElementStyle
}

export interface IIconButtonStyle {
    icon: IIconStyle
    element: IClickableElementStyle
    border: IBorderElementStyle
}

export interface ICardButtonStyle {
    textStyle: ITextStyle
    elementStyle: IStaticElementStyle
    border: IBorderElementStyle
}

export interface ITooltipStyle {
    primaryTextStyle: ITextStyle,
    secondaryTextStyle: ITextStyle,
    elementStyle: IStaticElementStyle
    border: IBorderElementStyle
}