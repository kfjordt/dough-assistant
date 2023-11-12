import { ColorWrapper } from './ColorWrapper';
export class ColorPalette {
    private firstColor: ColorWrapper;
    private secondColor: ColorWrapper;

    constructor(firstColor: ColorWrapper, secondColor: ColorWrapper) {
        this.firstColor = firstColor;
        this.secondColor = secondColor;
    }

    drawSample(factor: number) {
        const firstRgb = this.firstColor.toRgb()
        const secondRgb = this.secondColor.toRgb()

        return ColorWrapper.fromRgb(
            Math.round(firstRgb.r + factor * (secondRgb.r - firstRgb.r)),
            Math.round(firstRgb.g + factor * (secondRgb.g - firstRgb.g)),
            Math.round(firstRgb.b + factor * (secondRgb.b - firstRgb.b)),
        )
    }
}

export const darkModeColorPalette = new ColorPalette(
    ColorWrapper.fromHex("#FFFFFF"),
    ColorWrapper.fromHex("#21262d"),
)