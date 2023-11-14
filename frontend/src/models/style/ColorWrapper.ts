import Color from "color"

export class ColorWrapper {
    private model: Color

    private constructor(model: Color) {
        this.model = model;
    }

    getModel() {
        return this.model
    }

    static fromHex(hex: string) {
        return new ColorWrapper(Color(hex))
    }

    static fromRgb(r: number, g: number, b: number) {
        return new ColorWrapper(Color({ r: r, g: g, b: b }))
    }

    static transparent() {
        return new ColorWrapper(
            ColorWrapper.fromRgb(0, 0, 0).getModel().alpha(0) as Color
        )
    }

    toHex() {
        return this.model.hex()
    }

    toRgb() {
        return {
            r: this.model.red(),
            g: this.model.green(),
            b: this.model.blue(),
        }
    }

    toRgba() {
        return `rgba(${this.model.red()},${this.model.green()},${this.model.blue()},${this.model.alpha()})`
    }
}