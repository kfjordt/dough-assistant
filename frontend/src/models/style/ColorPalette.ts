import { ColorWrapper } from './ColorWrapper';

export class ColorPalette {
    firstColor: ColorWrapper;
    secondColor: ColorWrapper;

    constructor(firstColor: ColorWrapper, secondColor: ColorWrapper) {
        this.firstColor = firstColor;
        this.secondColor = secondColor;
    }

    drawSample(factor: number): ColorWrapper {
        const firstRgb = this.firstColor.toRgb()
        const secondRgb = this.secondColor.toRgb()

        return ColorWrapper.fromRgb(
            Math.round(firstRgb.r + factor * (secondRgb.r - firstRgb.r)),
            Math.round(firstRgb.g + factor * (secondRgb.g - firstRgb.g)),
            Math.round(firstRgb.b + factor * (secondRgb.b - firstRgb.b)),
        )
    }
}

export const getPalette = (mode: "dark" | "light") => {
    return mode === "dark"
        ? new ColorPalette(ColorWrapper.fromRgb(0, 0, 0), ColorWrapper.fromRgb(0, 0, 0),)
        : new ColorPalette(ColorWrapper.fromRgb(0, 0, 0), ColorWrapper.fromRgb(0, 0, 0),)
}