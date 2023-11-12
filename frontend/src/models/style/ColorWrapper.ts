import Color from "color"

export class ColorWrapper {
    private model: Color

    private constructor(model: Color) {
        this.model = model;
    }

    static fromHex(hex: string) {
        return new ColorWrapper(Color(hex))
    }

    static fromRgb(r: number, g: number, b: number) {
        return new ColorWrapper(Color({ r: r, g: g, b: b }))
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
}