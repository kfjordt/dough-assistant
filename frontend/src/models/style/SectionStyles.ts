import { ColorWrapper } from './ColorWrapper';
import { ColorPalette, getPalette } from './ColorPalette';
import { ICardStyle, IIconButtonStyle, ICardButtonStyle, ITooltipStyle } from './ComponentStyles';
import { ITextSizeFactors, IRoundedCornerSizes, standardTextSizeFactors, standardRoundedCornerSizes } from './StandardSizeFactors';
import { IIconStyle } from './ElementStyles';
import { StoreState } from '../../store/store';

export interface ISectionStyles {
    navBar: {
        main: ICardStyle
        calendarNavigationButton: IIconButtonStyle
        dateNavigationButton: ICardButtonStyle
        settingsButton: IIconButtonStyle
    },
    calendar: {
        dateLabels: ICardStyle
        todayDateLabel: ICardStyle
        main: ICardStyle
    },
    modals: {
        tooltip: ITooltipStyle,
        loading: IIconStyle
    }
}

export const getSectionStyles = (
    palette: ColorPalette,
    textSizeFactors?: ITextSizeFactors,
    roundedCornerSizes?: IRoundedCornerSizes,
    navbarIntensity?: number,
    mainAreaDefaultIntensity?: number,
    modalIntensity?: number
) => {
    const textSizeFactorsFinal = textSizeFactors ?? standardTextSizeFactors
    const roundedCornerSizesFinal = roundedCornerSizes ?? standardRoundedCornerSizes
    const navbarIntensityFinal = navbarIntensity ?? 0.8
    const mainAreaDefaultIntensityFinal = mainAreaDefaultIntensity ?? 0.7
    const modalIntensityFinal = modalIntensity ?? 0.75
    const navbarNegativeIntensity = 1 - navbarIntensityFinal


    const navBar = {
        main: {
            element: {
                backgroundColor: palette.drawSample(navbarIntensityFinal).toRgba()
            },
            text: {
                bold: false,
                color: palette.drawSample(navbarNegativeIntensity).toRgba(),
                size: textSizeFactorsFinal.headerM
            },
            border: {
                borderRadius: 0,
                thickness: 0,
                color: ColorWrapper.transparent().toRgba()
            }
        },
        calendarNavigationButton: {
            icon: {
                iconColor: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyM
            },
            element: {
                backgroundColor: palette.drawSample(0).toRgba(),
                hoverColor: palette.drawSample(0).toRgba(),
                pressColor: palette.drawSample(0).toRgba(),
            },
            border: {
                borderRadius: roundedCornerSizesFinal.s,
                thickness: 1,
                color: palette.drawSample(0).toRgba()
            }
        },
        dateNavigationButton: {
            textStyle: {
                bold: false,
                color: palette.drawSample(navbarNegativeIntensity).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            elementStyle: {
                backgroundColor: palette.drawSample(0).toRgba(),
            },
            border: {
                borderRadius: textSizeFactorsFinal.bodyS,
                thickness: textSizeFactorsFinal.bodyS,
                color: palette.drawSample(0).toRgba()
            }
        },
        settingsButton: {
            icon: {
                iconColor: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            element: {
                backgroundColor: palette.drawSample(0).toRgba(),
                hoverColor: palette.drawSample(0).toRgba(),
                pressColor: palette.drawSample(0).toRgba(),
            },
            border: {
                borderRadius: textSizeFactorsFinal.bodyS,
                thickness: textSizeFactorsFinal.bodyS,
                color: palette.drawSample(0).toRgba()
            }
        },
    }

    const calendar = {
        dateLabels: {
            element: {
                backgroundColor: palette.drawSample(0).toRgba()
            },
            text: {
                bold: false,
                color: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            border: {
                borderRadius: textSizeFactorsFinal.bodyS,
                thickness: textSizeFactorsFinal.bodyS,
                color: palette.drawSample(0).toRgba()
            }
        },
        todayDateLabel: {
            element: {
                backgroundColor: palette.drawSample(0).toRgba()
            },
            text: {
                bold: false,
                color: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            border: {
                borderRadius: textSizeFactorsFinal.bodyS,
                thickness: textSizeFactorsFinal.bodyS,
                color: palette.drawSample(0).toRgba()
            }
        },
        main: {
            element: {
                backgroundColor: palette.drawSample(0).toRgba()
            },
            text: {
                bold: false,
                color: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            border: {
                borderRadius: textSizeFactorsFinal.bodyS,
                thickness: textSizeFactorsFinal.bodyS,
                color: palette.drawSample(0).toRgba()
            }
        },
    }

    const modals = {
        tooltip: {
            primaryTextStyle: {
                bold: false,
                color: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            secondaryTextStyle: {
                bold: false,
                color: palette.drawSample(0).toRgba(),
                size: textSizeFactorsFinal.bodyS
            },
            border: {
                borderRadius: textSizeFactorsFinal.bodyS,
                thickness: textSizeFactorsFinal.bodyS,
                color: palette.drawSample(0).toRgba()
            },
            elementStyle: {
                backgroundColor: palette.drawSample(0).toRgba()
            },
        },
        loading: {
            iconColor: palette.drawSample(0).toRgba(),
            size: textSizeFactorsFinal.bodyS
        },
    }

    return {
        navBar: navBar,
        calendar: calendar,
        modals: modals
    }
}
