using Slon.SharedAssets.Domain;
using System;

namespace Slon.SharedAssets.Utility;

/// <summary>
/// Represents a range of dates and times.
/// </summary>
public class DateTimeRange : ValueObject
{
    /// <summary>
    /// Gets the starting date and time of the range.
    /// </summary>
    public DateTime Start { get; private set; }

    /// <summary>
    /// Gets the ending date and time of the range.
    /// </summary>
    public DateTime End { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeRange"/> class with specified start and end dates.
    /// </summary>
    /// <param name="start">The start date and time.</param>
    /// <param name="end">The end date and time.</param>
    /// <exception cref="ArgumentException">Thrown when the start date is greater than the end date.</exception>
    public DateTimeRange(DateTime start, DateTime end)
    {
        if (start > end)
        {
            throw new ArgumentException("Start date must be less than or equal to the end date.");
        }

        Start = start;
        End = end;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DateTimeRange"/> class with a specified start date and a duration.
    /// </summary>
    /// <param name="start">The start date and time.</param>
    /// <param name="duration">The duration of the range.</param>
    public DateTimeRange(DateTime start, TimeSpan duration) : this(start, start.Add(duration))
    {
    }

    /// <summary>
    /// Gets the duration of the range in seconds.
    /// </summary>
    /// <returns>The duration in seconds.</returns>
    public int DurationInSeconds() => (int)(End - Start).TotalSeconds;

    /// <summary>
    /// Gets the duration of the range in minutes.
    /// </summary>
    /// <returns>The duration in minutes.</returns>
    public int DurationInMinutes() => (int)Math.Round((End - Start).TotalMinutes, 0);

    /// <summary>
    /// Gets the duration of the range in hours.
    /// </summary>
    /// <returns>The duration in hours.</returns>
    public int DurationInHours() => (int)Math.Round((End - Start).TotalHours, 0);

    /// <summary>
    /// Gets the duration of the range in days.
    /// </summary>
    /// <returns>The duration in days.</returns>
    public int DurationInDays() => (int)(End - Start).TotalDays;

    /// <summary>
    /// Gets the duration of the range in weeks.
    /// </summary>
    /// <returns>The duration in weeks.</returns>
    public int DurationInWeeks() => DurationInDays() / 7;

    /// <summary>
    /// Gets the duration of the range in months.
    /// </summary>
    /// <returns>The duration in months.</returns>
    public int DurationInMonths() => Math.Abs((End.Year - Start.Year) * 12 + End.Month - Start.Month);

    /// <summary>
    /// Gets the duration of the range in years.
    /// </summary>
    /// <returns>The duration in years.</returns>
    public int DurationInYears() => End.Year - Start.Year;

    /// <summary>
    /// Creates a new <see cref="DateTimeRange"/> with a changed duration.
    /// </summary>
    /// <param name="newDuration">The new duration.</param>
    /// <returns>A new <see cref="DateTimeRange"/> with the updated duration.</returns>
    public DateTimeRange NewDuration(TimeSpan newDuration) => new DateTimeRange(this.Start, newDuration);

    /// <summary>
    /// Creates a new <see cref="DateTimeRange"/> with a changed starting date.
    /// </summary>
    /// <param name="newStart">The new start date.</param>
    /// <returns>A new <see cref="DateTimeRange"/> with the updated start date.</returns>
    public DateTimeRange NewStart(DateTime newStart) => new DateTimeRange(newStart, this.End);

    /// <summary>
    /// Creates a new <see cref="DateTimeRange"/> with a changed ending date.
    /// </summary>
    /// <param name="newEnd">The new end date.</param>
    /// <returns>A new <see cref="DateTimeRange"/> with the updated end date.</returns>
    public DateTimeRange NewEnd(DateTime newEnd) => new DateTimeRange(this.Start, newEnd);

    /// <summary>
    /// Determines whether the current range overlaps with the specified range.
    /// </summary>
    /// <param name="dateTimeRange">The range to check for overlap.</param>
    /// <exception cref="ArgumentNullException">Thrown when the specified range is null.</exception>
    /// <returns><c>true</c> if the ranges overlap; otherwise, <c>false</c>.</returns>
    public bool Overlaps(DateTimeRange dateTimeRange)
    {
        if (dateTimeRange is null)
        {
            throw new ArgumentNullException(nameof(dateTimeRange));
        }
        return
            this.Start < dateTimeRange.End &&
            this.End > dateTimeRange.Start;
    }

    /// <summary>
    /// Provides the components for value equality checks.
    /// </summary>
    /// <returns>The equality components.</returns>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}

