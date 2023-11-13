import { Point } from './Points';
import { Anchor } from './Anchor';

export class HtmlBoundingBox {
    upperLeft: Point
    height: number
    width: number

    constructor(upperLeft: Point, height: number, width: number) {
        this.upperLeft = upperLeft
        this.height = height
        this.width = width
    }

    getAnchorPoint(anchor: Anchor): Point {
        switch (anchor) {
            case Anchor.North:
                return new Point(this.upperLeft.x + this.width / 2  , this.upperLeft.y + this.height)
            case Anchor.Northeast:
                return new Point(this.upperLeft.x + this.width      , this.upperLeft.y + this.height)
            case Anchor.East:
                return new Point(this.upperLeft.x + this.width      , this.upperLeft.y + this.height / 2)
            case Anchor.Southeast:
                return new Point(this.upperLeft.x + this.width      , this.upperLeft.y)
            case Anchor.South:
                return new Point(this.upperLeft.x + this.width / 2  , this.upperLeft.y)
            case Anchor.Southwest:
                return new Point(this.upperLeft.x                   , this.upperLeft.y)
            case Anchor.West:
                return new Point(this.upperLeft.x                   , this.upperLeft.y + this.height / 2)
            case Anchor.Northwest:
                return new Point(this.upperLeft.x                   , this.upperLeft.y + this.height)
        }
    }
}