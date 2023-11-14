import { HtmlBoundingBox } from '../models/geometry/HtmlBoundingBox';
import { Anchor } from '../models/geometry/Anchor';
import { ITooltipStyle } from '../models/style/ComponentStyles';

export type TooltipState = {
    isTooltipLoaded: boolean,
    tooltipTimeoutId: NodeJS.Timeout 
    anchorElement?: HtmlBoundingBox
    tooltip?: Tooltip
}

export type Tooltip = {
    content: string
    shortcut?: string
    anchor: Anchor
}