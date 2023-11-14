export interface ITextSizeFactors {
    bodyXs: number
    bodyS: number
    bodyM: number
    bodyL: number
    bodyXl: number
    headerXs: number
    headerS: number
    headerM: number
    headerL: number
    headerXl: number
}

export interface IRoundedCornerSizes {
    xs: number
    s: number
    m: number
    l: number
    xl: number
}

export const standardRoundedCornerSizes = {
    xs: 2,
    s: 4,
    m: 6,
    l: 8,
    xl: 10
}

export const standardTextSizeFactors: ITextSizeFactors = {
    bodyXs: 8,
    bodyS: 10,
    bodyM: 12,
    bodyL: 16,
    bodyXl: 20,
    headerXs: 24,
    headerS: 28,
    headerM: 36,
    headerL: 48,
    headerXl: 72,
}

