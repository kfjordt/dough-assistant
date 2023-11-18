import type { ICloneable } from "./ICloneable"
import { differenceInDays } from 'date-fns'

export class DateTime implements ICloneable {
    private constructor(private dateModel: Date) { }

    static fromNumbers(year: number, month: number, day: number) {
        return new DateTime(new Date(year, month, day))
    }

    static fromDate(date: Date) {
        return new DateTime(date)
    }

    static fromUnix(unix: number) {
        return new DateTime(new Date(unix))
    }

    static fromNow() {
        return new DateTime(new Date(Date.now()))
    }

    clone() {
        return DateTime.fromNumbers(
            this.dateModel.getFullYear(),
            this.dateModel.getMonth(),
            this.dateModel.getDate()
        )
    }

    sameDayAs(day: DateTime) {
        const firstModel = this.getModel()
        const secondModel = day.getModel()

        return firstModel.getDate() === secondModel.getDate()
            && firstModel.getMonth() === secondModel.getMonth()
            && firstModel.getFullYear() === secondModel.getFullYear()
    }

    getMonthAsString() {
        return this.dateModel.toLocaleString('default', { month: 'long' })
    }

    getYearAsString() {
        return this.dateModel.getFullYear().toString()
    }

    setDayOfMonth(dayOfMonth: number) {
        this.dateModel.setDate(dayOfMonth + 1)
        return this
    }

    getDayOfWeek() {
        return this.dateModel.getDay() === 0
            ? 6
            : this.dateModel.getDay() - 1
    }

    getMonth() {
        return this.dateModel.getMonth()
    }

    subtractDays(days: number) {
        this.dateModel.setDate(this.dateModel.getDate() - days)
        return this
    }

    differenceInDays(dateTime: DateTime) {
        return differenceInDays(this.getModel(), dateTime.getModel())
    }

    getDaysInCurrentMonth(): DateTime[] {
        const initialDay = this.clone()
            .setDayOfMonth(0)
            .subtractDays(
                this.getDayOfWeek()
            )

        const lastDay = this.clone()
            .addMonths(1)
            .subtractDays(1)

        const totalDayCount = lastDay.differenceInDays(initialDay)
            + 1
            + 6 - lastDay.getDayOfWeek()

        let days: DateTime[] = []
        for (let i = 0; i < totalDayCount; i++) {
            days.push(initialDay.addDays(i))
        }

        return days
    }

    addDays(amount: number) {
        const dateCopy = this.clone()

        const currentDay = this.dateModel.getDate()
        dateCopy.dateModel.setDate(currentDay + amount)

        return DateTime.fromDate(dateCopy.dateModel)
    }

    toString() {
        return this.dateModel.toDateString()
    }

    addMonths(amount: number) {
        const dateCopy = this.clone()

        const currentDay = this.dateModel.getMonth()
        dateCopy.dateModel.setMonth(currentDay + amount)

        return DateTime.fromDate(dateCopy.dateModel)
    }

    getModel = () => {
        return this.dateModel
    }
}
