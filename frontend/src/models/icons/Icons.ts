import {
    LaCogSolid,
    LaCircleNotchSolid,
    LaAngleLeftSolid,
    LaAngleRightSolid
} from "oh-vue-icons/icons";

import { IconType } from "oh-vue-icons/types/icons";

export enum Icons {
    LeftArrow,
    RightArrow,
    Gear,
    Spinner
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
        default:
            throw new Error("Icon: " + icon + " has no corresponing component")
    }
}

export const allIcons: IconType[] = [
    LaCogSolid,
    LaCircleNotchSolid,
    LaAngleLeftSolid,
    LaAngleRightSolid
]