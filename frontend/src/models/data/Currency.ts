export type Currency = {
    currencyCode: string
    label: string,
    trend: Trend,
    rate: number
}

enum Trend {
    None,
    Up,
    Down
}