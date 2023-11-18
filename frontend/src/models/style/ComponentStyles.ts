import { ColorWrapper } from './ColorWrapper';

export interface IIconCardColorScheme {
    icon: string,
    background: string,
}

export interface IIconButtonColorScheme {
    icon: string,
    background: string,
    press: string,
    hover: string
}

export interface ICardColorScheme {
    text: string,
    background: string,
    border: string
}

export interface ICardButtonColorScheme {
    text: string,
    background: string,
    press: string,
    hover: string,
    border: string
}

export interface ITooltipColorScheme {
    primaryText: string,
    secondaryText: string,
    background: string
    border: string
}