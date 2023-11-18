import { ColorPalette, getPalette } from './ColorPalette';
import { IIconButtonColorScheme, ICardButtonColorScheme, ITooltipColorScheme, ICardColorScheme, IIconCardColorScheme } from './ComponentStyles';
import { ColorWrapper } from './ColorWrapper';

export interface ISectionColorScheme {
    navBar: {
        main: ICardColorScheme
        calendarNavigationButton: IIconButtonColorScheme
        dateNavigationButton: ICardButtonColorScheme
        settingsButton: IIconButtonColorScheme
    },
    calendar: {
        dateLabels: ICardColorScheme
        todayDateLabel: ICardColorScheme
        addNewExpenseButton: ICardButtonColorScheme
        expenseCards: ICardColorScheme
        main: ICardColorScheme
    },
    other: {
        tooltip: ITooltipColorScheme,
        loading: IIconCardColorScheme,
        modals: IIconButtonColorScheme
    }
}

export const getSectionStyles = (colorPalette: ColorPalette): ISectionColorScheme => {
    const mainIntensity = 0
    const contrastIntensity = 1 - mainIntensity

    const accentColor = ColorWrapper.fromRgb(35, 131, 226).toRgba()
    return {
        navBar: {
            main: {
                text: "",
                background: colorPalette.drawSample(mainIntensity + 0.1).toRgba(),
                border: ""
            },
            calendarNavigationButton: {
                icon: colorPalette.drawSample(contrastIntensity - 0.4).toRgba(),
                background: colorPalette.drawSample(mainIntensity + 0.1).toRgba(),
                press: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                hover: colorPalette.drawSample(mainIntensity + 0.15).toRgba()
            },
            settingsButton: {
                icon: colorPalette.drawSample(contrastIntensity - 0.4).toRgba(),
                background: colorPalette.drawSample(mainIntensity + 0.1).toRgba(),
                press: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                hover: colorPalette.drawSample(mainIntensity + 0.15).toRgba()
            },
            dateNavigationButton: {
                text: colorPalette.drawSample(contrastIntensity - 0.4).toRgba(),
                background: colorPalette.drawSample(mainIntensity + 0.1).toRgba(),
                press: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                hover: colorPalette.drawSample(mainIntensity + 0.15).toRgba(),
                border: ColorWrapper.transparent().toRgba()
            },
        },
        calendar: {
            dateLabels: {
                text: colorPalette.drawSample(contrastIntensity - 0.4).toRgba(),
                background: colorPalette.drawSample(mainIntensity + 0.25).toRgba(),
                border: ColorWrapper.transparent().toRgba()
            },
            todayDateLabel: {
                text: colorPalette.drawSample(contrastIntensity - 0.2).toRgba(),
                background: accentColor,
                border: ColorWrapper.transparent().toRgba()
            },
            addNewExpenseButton: {
                text: "",
                border: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                background: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                press: colorPalette.drawSample(mainIntensity + 0.14).toRgba(),
                hover: colorPalette.drawSample(mainIntensity + 0.19).toRgba()
            },
            expenseCards: {
                text: colorPalette.drawSample(contrastIntensity - 0).toRgba(),
                background: accentColor,
                border: colorPalette.drawSample(mainIntensity + 0.25).toRgba(),
            },
            main: {
                text: "",
                background: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                border: colorPalette.drawSample(mainIntensity + 0.25).toRgba()
            },
        },
        other: {
            // TO DO
            tooltip: {
                primaryText: colorPalette.drawSample(contrastIntensity).toRgba(),
                secondaryText: colorPalette.drawSample(contrastIntensity).toRgba(),
                background: colorPalette.drawSample(contrastIntensity).toRgba(),
                border: colorPalette.drawSample(contrastIntensity).toRgba()
            },
            loading: {
                icon: colorPalette.drawSample(contrastIntensity - 0.4).toRgba(),
                background: "",
            },
            modals: {
                icon: colorPalette.drawSample(contrastIntensity - 0.4).toRgba(),
                background: colorPalette.drawSample(mainIntensity + 0.1).toRgba(),
                press: colorPalette.drawSample(mainIntensity + 0.12).toRgba(),
                hover: colorPalette.drawSample(mainIntensity + 0.15).toRgba(),
            }
        }
    }
}