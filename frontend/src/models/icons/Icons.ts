import {
    LaCogSolid,
    LaCircleNotchSolid,
    LaAngleLeftSolid,
    LaAngleRightSolid,
LaSquare,
LaCheckSquare
} from "oh-vue-icons/icons";

import { IconType } from "oh-vue-icons/types/icons";

export enum Icons {
    LeftArrow,
    RightArrow,
    Gear,
    Spinner,
    CheckedCheckbox,
    EmptyCheckbox
}

export const getIconAsStr = (icon: Icons) => {
    switch (icon) {
        case Icons.Gear:
            return "la-cog-solid"
        case Icons.Spinner:
            return "la-circle-notch-solid"
        case Icons.LeftArrow:
            return "la-angle-left-solid"
        case Icons.RightArrow:
            return "la-angle-right-solid"
        case Icons.CheckedCheckbox:
            return "la-check-square"
        case Icons.EmptyCheckbox:
            return "la-square"
        default:
            throw new Error("Icon: " + icon + " has no corresponing component")
    }
}

export const allIcons: IconType[] = [
    LaCogSolid,
    LaCircleNotchSolid,
    LaAngleLeftSolid,
    LaAngleRightSolid,
    LaSquare,
    LaCheckSquare
]