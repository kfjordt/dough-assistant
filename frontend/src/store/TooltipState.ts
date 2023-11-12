export type TooltipState = {
    content: string
    header?: string
    anchor: TooltipAnchor
    position: { x: number, y: number }
}

export enum TooltipAnchor {
    West,
    Northwest,
    North,
    Northeast,
    East,
    Southeast,
    South,
    Southwest
}